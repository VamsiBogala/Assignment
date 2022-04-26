using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPIProject.Model;
namespace CRUDAPIProject.Repository
{
    public interface IUser
    {
        
   public  AddUserOutPutModel InsertUser(AddUserInPutModel  Model);

   public  EditUserOutPutModel UpdateUser(EditUserInPutModel  Model);
    
   public  DeleteUserOutPutModel DeleteUser(DeleteUserInPutModel  Model);
 
   public  Users GetUser(GetUserInPutModel  Model);
   public  List<Users> GetUsers();

    }
}