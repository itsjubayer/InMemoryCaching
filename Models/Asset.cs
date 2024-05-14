using System;
using System.Collections.Generic;

namespace InMemoryCaching.Models;

public partial class Asset
{
    public Guid AssetId { get; set; }

    public string? Barcode { get; set; }

    public string? SerialNumber { get; set; }

    public string? Pmguide { get; set; }

    public string AstId { get; set; } = null!;

    public string? ChildAsset { get; set; }

    public string? GeneralAssetDescription { get; set; }

    public string? SecondaryAssetDescription { get; set; }

    public int Quantity { get; set; }

    public string? Manufacturer { get; set; }

    public string? ModelNumber { get; set; }

    public string? Building { get; set; }

    public string? Floor { get; set; }

    public string? Corridor { get; set; }

    public string? RoomNo { get; set; }

    public string? Merno { get; set; }

    public string? EquipSystem { get; set; }

    public string? Comments { get; set; }

    public bool Issued { get; set; }

    public Guid FacilitySiteId { get; set; }
}
