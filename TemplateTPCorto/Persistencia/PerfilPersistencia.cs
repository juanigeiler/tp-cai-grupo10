using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;

namespace Persistencia
{
    public class PerfilPersistencia
    {
        public Perfil ObtenerPerfilUsuario(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();

            // Log para debug
            Console.WriteLine($"Buscando perfil para legajo: {legajo}");

            List<String> registros = dataBaseUtils.BuscarRegistro("usuario_perfil.csv");
            Console.WriteLine($"Registros encontrados en usuario_perfil.csv: {registros.Count}");

            string idPerfil = "";
            for (int i = 1; i < registros.Count; i++)
            {
                string[] datos = registros[i].Split(';');
                Console.WriteLine($"Comparando legajo {datos[0]} con {legajo}");
                if (datos[0] == legajo)
                {
                    idPerfil = datos[1];
                    Console.WriteLine($"idPerfil encontrado: {idPerfil}");
                    break;
                }
            }

            if (string.IsNullOrEmpty(idPerfil))
            {
                Console.WriteLine("No se encontró idPerfil para el legajo");
                return null;
            }

            List<String> perfiles = dataBaseUtils.BuscarRegistro("perfil.csv");
            Console.WriteLine($"Registros encontrados en perfil.csv: {perfiles.Count}");

            for (int i = 1; i < perfiles.Count; i++)
            {
                string[] datos = perfiles[i].Split(';');
                if (datos[0] == idPerfil)
                {
                    Console.WriteLine($"Perfil encontrado: {datos[1]}");
                    return new Perfil(perfiles[i]);
                }
            }

            Console.WriteLine("No se encontró el perfil");
            return null;
        }

        public List<Rol> ObtenerRolesPerfil(int idPerfil)
        {
            List<Rol> roles = new List<Rol>();
            DataBaseUtils dataBaseUtils = new DataBaseUtils();

            try
            {
                Console.WriteLine($"Buscando roles para perfil ID: {idPerfil}");

                // Primero obtener los IDs de roles asignados al perfil desde perfil_rol.csv
                List<String> perfilRoles = dataBaseUtils.BuscarRegistro("perfil_rol.csv");
                Console.WriteLine($"Registros en perfil_rol.csv: {perfilRoles.Count}");

                List<string> idsRolesAsignados = new List<string>();
                for (int i = 1; i < perfilRoles.Count; i++)
                {
                    string[] datos = perfilRoles[i].Split(';');
                    if (datos[0] == idPerfil.ToString())
                    {
                        Console.WriteLine($"Rol ID encontrado para perfil {idPerfil}: {datos[1]}");
                        idsRolesAsignados.Add(datos[1]);
                    }
                }

                if (idsRolesAsignados.Count == 0)
                {
                    Console.WriteLine($"No se encontraron roles asignados para el perfil {idPerfil}");
                    return roles;
                }

                // Luego obtener los detalles de cada rol desde rol.csv
                List<String> rolesRegistros = dataBaseUtils.BuscarRegistro("rol.csv");
                Console.WriteLine($"Registros en rol.csv: {rolesRegistros.Count}");

                foreach (string idRol in idsRolesAsignados)
                {
                    for (int i = 1; i < rolesRegistros.Count; i++)
                    {
                        string[] datos = rolesRegistros[i].Split(';');
                        if (datos[0] == idRol)
                        {
                            Console.WriteLine($"Agregando rol: {datos[1]} (ID: {datos[0]})");
                            roles.Add(new Rol(rolesRegistros[i]));
                            break; // Una vez encontrado el rol, pasamos al siguiente
                        }
                    }
                }

                Console.WriteLine($"Total de roles encontrados: {roles.Count}");
                return roles;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ObtenerRolesPerfil: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return roles;
            }
        }
    }
}