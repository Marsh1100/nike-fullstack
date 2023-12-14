using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Persistence;

public class ApiDbContextSeed
{
    public static async Task SeedAsync(ApiDbContext context, ILoggerFactory loggerFactory)
    {
         try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Rol>
                {
                    new() { Name = "Administrator" },
                    new() { Name = "Client" },
                    new() { Name = "WithoutRol" }
                };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }catch(Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiDbContext>();
            logger.LogError(ex.Message);
        }

        try
        {
            if(!context.Categories.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/category.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Category>();
                        List<Category> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new Category
                            {
                                Id = item.Id,
                                Name = item.Name
                            });
                        }
                        context.Categories.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if(!context.Products.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/product.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Product>();
                        List<Product> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new Product
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Price = item.Price,
                                Quantity = item.Quantity,
                                IdCategory = item.IdCategory,
                                Imagen = item.Imagen
                            });
                        }
                        context.Products.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            
            if(!context.Users.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/user.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<User>();
                        List<User> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new User
                            {
                                Id = item.Id,
                                IdenNumber = item.IdenNumber,
                                UserName=item.UserName,
                                Email = item.Email,
                                Password = item.Password
                            });
                        }
                        context.Users.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if(!context.UserRoles.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/userrol.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<UserRol>();
                        List<UserRol> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new UserRol
                            {
                                IdUser= item.IdUser,
                                IdRol = item.IdRol
                            });
                        }
                        context.UserRoles.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }


            if(!context.Users.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/client.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Client>();
                        List<Client> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new Client
                            {
                                Id = item.Id,
                                IdUser = item.IdUser,
                                FirstName = item.FirstName,
                                SecondName = item.SecondName,
                                Surname = item.Surname,
                                SecondSurname = item.SecondSurname
                            });
                        }
                        context.Clients.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
        }catch(Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiDbContext>();
            logger.LogError(ex.Message);
        }
        
    } 
}
