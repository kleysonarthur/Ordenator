using System.Collections.Generic;

namespace Ordenator.Models
{
    public class Profile
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        



        public Profile()
        {

        }
        public Profile(int id, string name)
        {
            Id = id;
            Name = name;
            
        }
    }
}
