using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace web_app_asp_net_mvc_code_first.Models.Enums
{
    public enum Gender
    {
        [Display(Name = "Agender")]
        Agender = 1,

        [Display(Name = "Androgyne")]
        Androgyne = 2,

        [Display(Name = "Androgynous")]
        Androgynous = 3,

        [Display(Name = "Bigender")]
        Bigender = 4,

        [Display(Name = "Cis")]
        Cis = 5,

        [Display(Name = "CisFemale")]
        CisFemale = 6,

        [Display(Name = "CisMale")]
        CisMale = 7,

        [Display(Name = "CisMan")]
        CisMan = 8,

        [Display(Name = "CicWoman")]
        CicWoman = 9,

        [Display(Name = "Cisgender")]
        Cisgender = 10,

        [Display(Name = "CisgenderFemale")]
        CisgenderFemale = 11,

        [Display(Name = "CisgenderMale")]
        CisgenderMale = 12,

        [Display(Name = "CisgenderMan")]
        CisgenderMan = 13,

        [Display(Name = "CisgenderWoman")]
        CisgenderWoman = 14,

        [Display(Name = "FemaletoMale")]
        FemaletoMale = 15,

        [Display(Name = "FTM")]
        FTM = 16,

        [Display(Name = "GenderFluid")]
        GenderFluid = 17,

        [Display(Name = "GenderNonconforming")]
        GenderNonconforming = 18,

        [Display(Name = "GenderQuestioning")]
        GenderQuestioning = 19,

        [Display(Name = "GenderVariant")]
        GenderVariant = 20,

        [Display(Name = "Genderqueer")]
        Genderqueer = 21,

        [Display(Name = "Intersex")]
        Intersex = 22,

        [Display(Name = "MaletoFemale")]
        MaletoFemale = 23,

        [Display(Name = "MTF")]
        MTF = 24,

        [Display(Name = "Neither")]
        Neither = 25,

        [Display(Name = "Neutrois")]
        Neutrois = 26,

        [Display(Name = "NonBinary")]
        NonBinary = 27,

        [Display(Name = "Other")]
        Other = 28,

        [Display(Name = "Pangender")]
        Pangender = 29,

        [Display(Name = "Trans")]
        Trans = 30,

        [Display(Name = "TransFemale")]
        TransFemale = 31,

        [Display(Name = "TransMale")]
        TransMale = 32,

        [Display(Name = "TransMan")]
        TransMan = 33,

        [Display(Name = "TransPerson")]
        TransPerson = 34,

        [Display(Name = "TransWoman")]
        TransWoman = 35,

        [Display(Name = "Transexual")]
        Transexual = 36,

        [Display(Name = "TransexualFemale")]
        TransexualFemale = 37,

        [Display(Name = "TransexualMale")]
        TransexualMale = 38,

        [Display(Name = "TransexualMan")]
        TransexualMan = 39,

        [Display(Name = "TransexualPerson")]
        TransexualPerson = 40,

        [Display(Name = "TransexualWoman")]
        TransexualWoman = 41,

        [Display(Name = "TransgenderFemale")]
        TransgenderFemale = 42,

        [Display(Name = "TransgenderMale")]
        TransgenderMale = 43,

        [Display(Name = "TransgenderMan")]
        TransgenderMan = 44,

        [Display(Name = "TransgenderPerson")]
        TransgenderPerson = 45,

        [Display(Name = "TransgenderWoman")]
        TransgenderWoman = 46,

        [Display(Name = "Transmasculine")]
        Transmasculine = 47,

        [Display(Name = "TwoSpirit")]
        TwoSpirit = 48,

        [Display(Name = "Pivosexual")]
        Pivosexual = 49,

        [Display(Name = "AttackHelicopter")]
        AttackHelicopter = 50,
    }
}