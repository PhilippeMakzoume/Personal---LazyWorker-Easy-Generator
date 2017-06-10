using LazyGenerator_V2.Sources.Pets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LazyGenerator_V2
{
    public partial class FMountOption : Form
    {
        public FMountOption()
        {
            InitializeComponent();
        }

        private void FMountOption_Load(object sender, EventArgs e)
        {
            MountItemLibrary.LoadMountItemInfoLibrary();
            PetItemLibrary.LoadPetItemInfoLibrary();
        }

        // ========================= Items ============================ //
        private void btn_ItemStoreDictionary_Click(object sender, EventArgs e)
        {

        }

        private void btn_ItemGenerate_Click(object sender, EventArgs e)
        {
            string MountspellID = txt_ItemID.Text;
            string ItemName = txt_ItemName.Text;
            string ItemID = txt_ItemID.Text;
            string ItemDisplayID = txt_ItemDisplayID.Text;
            string ItemIconString = txt_ItemIconName.Text;
            string Description = rtxt_ItemDescription.Text;
            string Quality = cbx_ItemQuality.Text;
            string Type = cbx_ItemType.Text;

            switch (Quality)
            {
                case "Poor":
                    Quality = "1";
                    break;
                case "Common":
                    Quality = "2";
                    break;
                case "Rare":
                    Quality = "3";
                    break;
                case "Epic":
                    Quality = "4";
                    break;
                case "Legendary":
                    Quality = "5";
                    break;
            }

            ItemGenerator.GenerateItem(MountspellID, ItemName, ItemID, Description, ItemDisplayID, ItemIconString, Quality, Type);
        }

        private void txt_ItemID_TextChanged(object sender, EventArgs e)
        {

            if (cbx_LocalLibrary.Checked)
            {
                if (cbx_ItemType.Text == "Mount")
                {
                    txt_ItemSpellID.Text = MountItemLibrary.GetLocalSpell(txt_ItemID.Text);
                    txt_ItemName.Text = MountItemLibrary.GetLocalItemName(txt_ItemID.Text);
                    txt_ItemIconName.Text = MountItemLibrary.GetLocalIconName(txt_ItemID.Text);
                }
                else
                {
                    txt_ItemSpellID.Text = PetItemLibrary.GetLocalSpellID(txt_ItemID.Text);
                    txt_ItemName.Text = PetItemLibrary.GetLocalItemName(txt_ItemID.Text);
                    txt_ItemIconName.Text = PetItemLibrary.GetLocalIconName(txt_ItemID.Text);
                }
            }
            else if (cbx_WoWHead.Checked)
            {
                // Do something
            }
        }

        // Mount & Pet Description
        private void cbx_ItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_ItemType.Text == "Mount")
                rtxt_ItemDescription.Text = "Teaches you how to summon this mount.  This is a very fast mount.";
            else
                rtxt_ItemDescription.Text = "Teaches you how to summon this companion.";
        }

        // ========================= Creatures ============================ //
        private void btn_GenerateModel_Click(object sender, EventArgs e)
        {
            string ModelData = "0", ModelName = "", ModelID = "0", Texture1 = "", Texture2 = "", Texture3 = "";

            ModelData = txt_CreatureModelData.Text;
            ModelName = txt_CreatureModelName.Text;
            ModelID = txt_CreatureDisplayId.Text;
            Texture1 = txt_Texture1.Text;
            Texture2 = txt_Texture2.Text;
            Texture3 = txt_Texture3.Text;

            ModelDataGenerator.GenerateCreatureModel(ModelData, ModelName, ModelID, Texture1, Texture2, Texture3);
        }
    }
}
