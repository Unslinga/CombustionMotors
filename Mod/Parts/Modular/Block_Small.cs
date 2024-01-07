using CombustionMotors.Behaviours;
using CombustionMotors.Behaviours.CC97;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Modular;

class Block_Small : Part
{
    public Block_Small() : base("CombustionMotors/assets/combustion_motors", "small_block", 940625062889631, "Small Engine Block", "Props", 10f)
    {
        AddAttachmentPoint(
            "FixedBottom",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, -0.05f, 0f),
            new Vector3(0f, 180f, 180f),
            Vector3Int.one,
            true
        );
        
        AddAttachmentPoint(
            "Cylinder",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, 0.05f, 0f),
            new Vector3(0f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "Crankshaft",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsFemale | AlignmentFlags.IsBidirectional,
            new Vector3(0f, 0f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one
        );
        
        AddLinkPoint("ECU", "Electronics", new Vector3(-0.1f, 0f, 0), can_send: false);
        AddBehaviour<DisableCollisonBehaviour>();
        AddBehaviour<CrankCase97Behaviour>();
        AddBehaviour<BlockBehaviour>();
    }
}