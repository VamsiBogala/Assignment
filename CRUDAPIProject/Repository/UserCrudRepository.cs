using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPIProject.Model;
using  LiteDB;
using AutoMapper;
namespace CRUDAPIProject.Repository
{
    public static class UserCrudRepository
    {
        

        public static void InsertUser(AddUserInPutModel model)

        {
       // Open database (or create if not exits)
        using(var db = new LiteDatabase(@"NoSqlLiteDataBase.db"))
        {
            // Get user collection
            var users = db.GetCollection<Users>("users");
                 //Initialize the mapper
            var configUser = new MapperConfiguration(cfg =>
                    cfg.CreateMap<AddUserInPutModel, Users>()
                    .ForMember(dest => dest.address, act => act.MapFrom(src => src.address))
                    .ForMember(dest => dest.company, act => act.MapFrom(src => src.company))
                );

                 //Using automapper
            var mapper = new Mapper(configUser);
            var mappingUser = mapper.Map<Users>(model);
            // Create your new user instance
            //var user = new User
            //{ 
             //   Name = "Shehryar Khan", 
               // Email = "shehryarkn@gmail.com"
            //};
            // Insert new user document (Id will be auto-incremented)
            users.Insert(mappingUser);
          //  var result = users.Find(x => x.Email == "shehryarkn@gmail.com").FirstOrDefault();
           // Console.WriteLine(result.Name);
            // Update a document inside a collection
            //user.Name = "S Khan";
            //users.Update(user);
            // Index document using a document property
           // users.EnsureIndex(x => x.Name);
        }
            
        }

         public static void UpdateUser( EditUserInPutModel model)

        {
 // Open database (or create if not exits)
        using(var db = new LiteDatabase(@"NoSqlLiteDataBase.db"))
        {
                // Get user collection
            var users = db.GetCollection<Users>("users");
                 //Initialize the mapper
            var configUser = new MapperConfiguration(cfg =>
                    cfg.CreateMap<EditUserInPutModel, Users>()
                    .ForMember(dest => dest.address, act => act.MapFrom(src => src.address))
                    .ForMember(dest => dest.company, act => act.MapFrom(src => src.company))
                );

                 //Using automapper
            var mapper = new Mapper(configUser);
            var user = mapper.Map<EditUserInPutModel, Users>(model);

             users.Update(user);
            // Index document using a document property
           // users.EnsureIndex(x => x.Name);
        }
            
        }

         public static bool DeleteUser(DeleteUserInPutModel model)
        {
       //Open database (or create if not exits)
        using(var db = new LiteDatabase(@"NoSqlLiteDataBase.db"))
        {
            // Get user collection
            var users = db.GetCollection<Users>("users");
          
            var result = users.Find(x => x.Id == model.Id).FirstOrDefault();
           
                    if (result == null)
                        return false;

                   return users.Delete(new BsonValue(model.Id));
        }
            
        }

        public static Users  GetUser(GetUserInPutModel model)
        {
 // Open database (or create if not exits)
        using(var db = new LiteDatabase(@"NoSqlLiteDataBase.db"))
        {
            // Get user collection
            var users = db.GetCollection<Users>("users");
            var result = users.Find(x => x.Id ==model.Id).FirstOrDefault();
            return result;
        }
            
        }

        
        public static List<Users>  GetUsers()
        {
 // Open database (or create if not exits)
        using(var db = new LiteDatabase(@"NoSqlLiteDataBase.db"))
        {
            List<Users> usersList=new List<Users>();
            // Get user collection
            var users = db.GetCollection<Users>("users");
             foreach (var item in users.FindAll())
            {
           usersList.Add(item);
            }
            return usersList;
        }
            
        }
    }
}