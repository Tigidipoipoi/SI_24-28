using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class is a shame and is meant to be replaced by a .json, .xml or any other common data storage file
/// </summary>
public static class ThemeList {
    static List<string> s_ThemeList;

    public static void PopulateThemes() {
        if (s_ThemeList != null)
            return;

        s_ThemeList = new List<string>();

        s_ThemeList.Add("A l’heure du thé");
        s_ThemeList.Add("Ainsi bat la vie ");
        s_ThemeList.Add("Amitié dans la tempête");
        s_ThemeList.Add("Ballade lyrique");
        s_ThemeList.Add("Bateau ivre");
        s_ThemeList.Add("Beauté formelle");
        s_ThemeList.Add("Banquet du galérien");
        s_ThemeList.Add("Caprices des Dieux");
        s_ThemeList.Add("Carnaval des timorés");
        s_ThemeList.Add("Carrefour de la nuit");
        s_ThemeList.Add("Cauchemar d’étoile");
        s_ThemeList.Add("Chacun pour toi");
        s_ThemeList.Add("Ciné-surprise");
        s_ThemeList.Add("Démons et merveilles");
        s_ThemeList.Add("En orbite");
        s_ThemeList.Add("Faiseur de pluie");
        s_ThemeList.Add("Fifre et flonflons");
        s_ThemeList.Add("Gouffre fantastique");
        s_ThemeList.Add("Imprévu");
        s_ThemeList.Add("Jardin d’hiver");
        s_ThemeList.Add("L’ours palmé ");
        s_ThemeList.Add("Lambada à Charleroi");
        s_ThemeList.Add("Lave-toi et marche");
        s_ThemeList.Add("Mannequin grossier");
        s_ThemeList.Add("Mélancolie de gargouille");
        s_ThemeList.Add("Nature Morte");
        s_ThemeList.Add("Neige grecque");
        s_ThemeList.Add("Ombres et lumières");
        s_ThemeList.Add("Parfums de fleurs");
        s_ThemeList.Add("Raffinement démoniaque");
        s_ThemeList.Add("Secret de Molière");
        s_ThemeList.Add("Vents contraires");
    }

    public static string GetATheme() {
        if (s_ThemeList.Count < 1) {
            return null;
        }

        int rngIndex = Random.Range(0, s_ThemeList.Count);
        string rngTheme = s_ThemeList[rngIndex];
        s_ThemeList.RemoveAt(rngIndex);

        return rngTheme;
    }
}
