namespace Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("transac")]
    public partial class transac
    {
        public int id { get; set; }

        public int type_id { get; set; }

        public int compte_id { get; set; }

        public virtual compte compte { get; set; }

        public virtual type type { get; set; }
    }
}
