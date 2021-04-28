using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace devSharp.Services
{
    public class SavedUser
    {

        private String name;
        private int setAmount;
        
        public SavedUser(String name)
        {
            this.name = name;
        }

        public SavedUser(String name, int setAmount)
        {
            this.name = name;
            this.setAmount = setAmount;
        }

        public void setName(String name)
        {
            this.name = name;
        }
    }
}