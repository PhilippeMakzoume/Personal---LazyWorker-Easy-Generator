using LazyGenerator_V2.Sources.ExtendedCost;
using LazyGenerator_V2.Sources.Extension;
using LazyGenerator_V2.Sources.Gems;
using LazyGenerator_V2.Sources.Pets;
using LazyGenerator_V2.Sources.Titles;
using LazyGenerator_V2.Sources.Image;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LazyGenerator_V2
{
    public partial class Fmain : Form
    {
        public Fmain()
        {
            InitializeComponent();
        }
        // Loading
        private void Fmain_Load(object sender, EventArgs e)
        {
            SpellLibrary.LoadSpellIconLibrary();
            MountLibrary.LoadMountInfoLibrary();
            PetLibrary.LoadPetInfoLibrary();
        }
        // ========================================= Mounts ========================================= //
        private void cbxCustomIcon_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCustomIcon.Checked)
                txtm_SpellIconID.Enabled = true;
            else
                txtm_SpellIconID.Enabled = false;
        }
        
        private void txtm_spellID_TextChanged(object sender, EventArgs e)
        {
            if (cbxParseLocal.Checked)
            {
                txtm_spellname.Text = MountLibrary.GetKeyMountName(txtm_spellID.Text);
                txtm_Description.Text = MountLibrary.GetKeyMountDescription(txtm_spellID.Text);
                txtm_creaturedisplayid.Text = MountLibrary.GetKeyDisplayID(txtm_spellID.Text);
                txtm_CreatureID.Text = MountLibrary.GetKeyCreatureEntry(txtm_spellID.Text);
                txtm_spellicon.Text = MountLibrary.GetKeyIconName(txtm_spellID.Text);
            }
            else if (cbxMountParseWoWhead.Checked)
            {
                // Get Info
            }
        }

        private void txtm_spellicon_TextChanged(object sender, EventArgs e)
        {
            if (!cbxCustomIcon.Checked)
                txtm_SpellIconID.Text = SpellLibrary.GetKeySpellIcon(txtm_spellicon.Text.ToLower());

            LoadImageFromUrl.LoadIconFromWoWHead(MountPictureBox, txtm_spellicon.Text);
        }
        
        private void btnSaveDictionary_Click(object sender, EventArgs e)
        {
            string CreatureID, CreatureDisplayID, SpellID, SpellIconName, SpellName, SpellDescription;

            CreatureDisplayID = txtm_creaturedisplayid.Text;
            CreatureID = txtm_CreatureID.Text;
            SpellID = txtm_spellID.Text;
            SpellName = txtm_spellname.Text;
            SpellDescription = txtm_Description.Text;
            SpellIconName = txtm_spellicon.Text;

            MountLibrary.AddToMountLibrary(SpellID, CreatureID, SpellName, SpellDescription, CreatureDisplayID, SpellIconName);
        }

        private void btnMountGenerateCSV_Click(object sender, EventArgs e)
        {
            string CreatureID, CreatureDisplayID, SpellID, SpellIconID, SpellIconName, SpellName, SpellDescription;
            string Type, adaptive, lang;

            CreatureDisplayID = txtm_creaturedisplayid.Text;
            CreatureID = txtm_CreatureID.Text;
            SpellID = txtm_spellID.Text;
            SpellIconID = txtm_SpellIconID.Text;
            SpellIconName = txtm_spellicon.Text;
            SpellName = txtm_spellname.Text;
            SpellDescription = txtm_Description.Text;
            Type = cbxMountType.Text;
            lang = cbm_Language.Text;

            if (cbxMountAdaptive.Checked)
                adaptive = "1";
            else
                adaptive = "0";

            MountGenerator.GenerateMount(CreatureID, CreatureDisplayID, SpellID, SpellIconID, SpellName, SpellDescription, Type, lang, adaptive);

            if (cbxCustomIcon.Checked)
                SpellIconGenerator.GenerateSpellIcon(SpellIconID, SpellIconName);
        }

        private void btnMoreOption_Click(object sender, EventArgs e)
        {
            FMountOption CF = new FMountOption();
            CF.StartPosition = FormStartPosition.Manual;
            CF.Location = new Point(this.ClientSize.Width, this.ClientSize.Height);
            CF.Show();
        }

        // ========================================= Pets ========================================= //
        private void txtPetSpellID_TextChanged(object sender, EventArgs e)
        {
            if (cbx_pet_parselocal.Checked)
            {
                txtPetName.Text = PetLibrary.GetKeyPetSpellName(txtPetSpellID.Text);
                txtPetIconID.Text = PetLibrary.GetKeyPetSpellIconID(txtPetSpellID.Text);
                txtPetIcon.Text = PetLibrary.GetKeySpellIconName(txtPetSpellID.Text);
                txtPetCreatureID.Text = PetLibrary.GetKeyPetCreatureID(txtPetSpellID.Text);
                txtPetDisplayID.Text = PetLibrary.GetKeyPetCreatureDisplayID(txtPetSpellID.Text);
            }
            else if (cbx_pet_parsewowhead.Checked)
            {
                // todo
            }
        }
        
        private void txtPetIcon_TextChanged(object sender, EventArgs e)
        {
            if (!cbx_custom_icon.Checked)
                txtm_SpellIconID.Text = SpellLibrary.GetKeySpellIcon(txtPetIcon.Text.ToLower());

            LoadImageFromUrl.LoadIconFromWoWHead(PetPictureBox, txtPetIcon.Text);
        }

        private void btn_Pet_GenerateCsv_Click(object sender, EventArgs e)
        {
            string PetSpellID = txtPetSpellID.Text;
            string PetSpellName = txtPetName.Text;
            string SpellIconID = txtPetIconID.Text;
            string SpellIcon = txtPetIcon.Text;
            string CreatureID = txtPetCreatureID.Text;
            string CreatureDisplayID = txtPetDisplayID.Text;
            string lang = cbx_pet_language.Text;

            PetGenerator.GeneratePet(PetSpellID, PetSpellName, SpellIconID, SpellIcon, CreatureID, CreatureDisplayID, lang);

            if (cbx_custom_icon.Checked)
                SpellIconGenerator.GenerateSpellIcon(SpellIconID, SpellIcon);
        }

        private void cbx_custom_icon_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_custom_icon.Checked)
                txtPetIconID.Enabled = true;
            else
                txtPetIconID.Enabled = false;
        }

        private void btn_Pet_StoreDictionnary_Click(object sender, EventArgs e)
        {
            string PetSpellID = txtPetSpellID.Text;
            string PetSpellName = txtPetName.Text;
            string SpellIconID = txtPetIconID.Text;
            string SpellIcon = txtPetIcon.Text;
            string CreatureID = txtPetCreatureID.Text;
            string CreatureDisplayID = txtPetDisplayID.Text;

            PetLibrary.AddToPetXmlLibrary(PetSpellID, CreatureID, CreatureDisplayID, PetSpellName, SpellIcon, SpellIconID);
            PetLibrary.LoadPetInfoLibrary();
        }

        private void btn_Pet_MoreOption_Click(object sender, EventArgs e)
        {
            FMountOption CF = new FMountOption();
            CF.StartPosition = FormStartPosition.Manual;
            CF.Location = new Point(this.ClientSize.Width, this.ClientSize.Height);
            CF.Show();
        }

        // ========================================= Titles ========================================= //
        private void btnGenerateTitle_Click(object sender, EventArgs e)
        {
            int TitleID;
            TitleID = int.Parse(txtTitleID.Text);

            TitleGenerator.GenerateTitle(txtTitleMale.Text, txtTitleFemale.Text, TitleID, cbxTitleLanguage.Text);
        }

        // ========================================= Gems ========================================= //
        private void btnGenerateGem_Click(object sender, EventArgs e)
        {
            int GemProperties;
            GemProperties = int.Parse(txtGemPropID.Text);

            GemGenerator.GenerateGem(GemProperties, cbxGemColor.Text);
            GemItemEnchantementGenerator.GenerateGemItemEnchantement(GemProperties, cbxGemType1.Text, txtGemStats1.Text, cbxGemType2.Text, txtGemStats2.Text, txtGemItemID.Text, cbxMultiStats.Checked, cbxGemLanguage.Text);
            GemSQLGenerator.GenerateGemSQL(GemProperties, cbxGemColor.Text.After("- "), txtGemName.Text, int.Parse(txtGemItemID.Text), int.Parse(txtGemDisplayID.Text), cbxGemQuality.Text.Before(" -"));

        }

        private void cbxMultiStats_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMultiStats.Checked)
            {
                cbxGemType2.Enabled = true;
                txtGemStats2.Enabled = true;
            }
            else
            {
                cbxGemType2.Enabled = false;
                txtGemStats2.Enabled = false;
            }
        }

        // ========================================= Extended Costs ========================================= //
        private void btnGenerateExte_Click(object sender, EventArgs e)
        {
            ExtendedCostGenerator.GenerateExtendedCost(txtExteID.Text, txtExteReqHonorCount.Text, txtExteReqArenaCount.Text, cbxArenaSlot.Text.Before(" -"),
                txtExteReqItem1.Text, txtExteReqItemCount1.Text, txtExteReqItem2.Text, txtExteReqItemCount2.Text,
                txtExteReqItem3.Text, txtExteReqItemCount3.Text, txtExteReqItem4.Text, txtExteReqItemCount4.Text,
                txtExteReqItem5.Text, txtExteReqItemCount5.Text, txtExteReqPersonalRating.Text);
        }
    }
}
