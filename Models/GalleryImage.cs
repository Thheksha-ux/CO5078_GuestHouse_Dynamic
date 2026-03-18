namespace CO5078_GuestHouse_Dynamic.Models
{
    public class GalleryImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = "";
        public string Caption { get; set; } = "";
        public int PropertyId { get; set; }
    }
}