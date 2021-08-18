using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NLayerProject.Core.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanının girilmesi zorunludur")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} alanının girilmesi zorunludur")]
        public string Surname { get; set; }


        //Yeni model tanımladıktan sonra Dbset olarak appdbcontexte kaydetmem gerekiyor.
    }
}
