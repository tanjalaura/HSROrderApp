#region

using System.Runtime.Serialization;
using HsrOrderApp.SharedLibraries.DTO.Base;
using HsrOrderApp.SharedLibraries.SharedEnums;

#endregion

namespace HsrOrderApp.SharedLibraries.DTO
{
    [DataContract]
    public class SupplierListDTO : DTOBase
    {
        public SupplierListDTO()
        {
            this.AccountNumber = string.Empty;
            this.Name = string.Empty;
            this.CreditRating = SharedEnums.CreditRating.Average;
            this.PreferredSupplierFlag = false;
            this.ActiveFlag = false;
        }

        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public CreditRating CreditRating { get; set; }

        [DataMember]
        public bool PreferredSupplierFlag { get; set; }

        [DataMember]
        public bool ActiveFlag { get; set; }
    }
}