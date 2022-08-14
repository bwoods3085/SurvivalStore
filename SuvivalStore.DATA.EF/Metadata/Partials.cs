using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuvivalStore.DATA.EF.Models//.Metadata
{
    #region Category
    [ModelMetadataType(typeof(CategoryMetadata))]
    public partial class Category { }
    #endregion

    #region Gear
    [ModelMetadataType(typeof(GearMetadata))]
    public partial class Gear { }
    #endregion

    #region GearStatus
    [ModelMetadataType(typeof(GearStatusMetadata))]
    public partial class GearStatus { }
    #endregion

    #region Order
    [ModelMetadataType(typeof(OrderMetadata))]
    public partial class Order { }
    #endregion

    #region UserDetail
    [ModelMetadataType(typeof(UserDetailMetadata))]
    public partial class UserDetail { }
    #endregion


}
