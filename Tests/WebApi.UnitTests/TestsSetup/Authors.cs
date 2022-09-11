using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestsSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                    new Author{
                        Name="Frank",
                        Surname="Herbert",
                        Birthday=new DateTime(1920,08,10)
                    },
                    new Author{
                        Name="James",
                        Surname="Clear",
                        Birthday=new DateTime(1980,06,6)
                    },
                    new Author{
                        Name="George",
                        Surname="Orwell",
                        Birthday=new DateTime(1903,04,4)
                    }
                );
        }
    }
    
}