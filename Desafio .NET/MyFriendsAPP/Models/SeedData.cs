using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyFriendsAPP.Data;
using System;
using System.Linq;

namespace MyFriendsAPP.Models
{
    public static class SeedData
    {
       public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcFriendContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcFriendContext>>()))
            {
                if (context.Friend.Any())
                {
                    return;
                }

                context.Friend.AddRange(
                    new Friend
                    {
                        Nome = "Julio César",
                        Rua = "Rua Baltar, 180",
                        Cidade = "São Paulo",
                        Estado = "São Paulo",
                        Pais = "Brasil",
                        Latitude = -23.6014369,
                        Longitude = -46.5607609,
                        Distancia = 0
                    },

                    new Friend
                    {
                        Nome = "Leticia Azul",
                        Rua = "Rua Costa Rica, 73",
                        Cidade = "Santo André",
                        Estado = "São Paulo",
                        Pais = "Brasil",
                        Latitude = -23.6406873,
                        Longitude = -46.5145176,
                        Distancia = 0

                    },

                    new Friend
                    {
                        Nome = "Caique Porfirio",
                        Rua = "Estrada das Lágrimas, 1935",
                        Cidade = "São Caetano do Sul",
                        Estado = "São Paulo",
                        Pais = "Brasil",
                        Latitude = -23.6467414,
                        Longitude = -46.5753657,
                        Distancia = 0
                    },

                    new Friend
                    {
                        Nome = "Quenia Recaldes",
                        Rua = "Av Pres. wilson, 6351",
                        Cidade = "São Paulo",
                        Estado = "São Paulo",
                        Pais = "Brasil",
                        Latitude = -23.6035892,
                        Longitude = -46.5819421,
                        Distancia = 0
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}