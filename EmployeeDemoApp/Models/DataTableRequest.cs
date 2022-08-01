namespace EmployeeDemoApp.Models
{
    public class DataTableRequest
    {

        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int iDisplayLength { get; set; } = 5;

        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int iDisplayStart { get; set; } = 0;

    }
}
