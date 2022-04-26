using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPIProject.Model
{
    public class Users
    {

                public int Id{get;set;}

                public string Name{get;set;}

                public string Username{get;set;}
              
                public string Email{get;set;}
                
                public string Phone{get;set;}

                public string Website{get;set;}

                public Address  address{get;set;}
                              
                public Company  company{get;set;}


    }

    public class Address
    {
       public string Suite{get;set;}
       public string Street{get;set;}
       public string City{get;set;}
       public string Zipcode{get;set;}    

       public   Geo geo{get;set;}    
    }

    public class Geo
    {
       public string lat{get;set;}
       public string lng{get;set;}
        
    }

    
    public class Company
    {
       public string name{get;set;}
       public string catchPhrase{get;set;}
       public string bs{get;set;}

    }
}