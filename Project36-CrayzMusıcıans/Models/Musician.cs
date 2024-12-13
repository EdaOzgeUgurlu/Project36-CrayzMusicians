using Microsoft.OpenApi.MicrosoftExtensions;

namespace Project36_CrazyMusicians.Model
{
    //We are defining the properties of the Musician class.
    public class Musician
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Profession { get; set; } = "";
        public string FunFeature { get; set; } = "";

    }
}
