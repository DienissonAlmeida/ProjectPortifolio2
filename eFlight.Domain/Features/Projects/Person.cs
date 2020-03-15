using System;

namespace ProjectsPortifolio.Domain.Features.Projects
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Cpf { get; set; }
        public bool Employee { get; set; }
    }   
}