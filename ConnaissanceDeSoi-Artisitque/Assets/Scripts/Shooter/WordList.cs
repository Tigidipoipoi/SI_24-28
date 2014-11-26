using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class is a shame and is meant to be replaced by a .json, .xml or any other common data storage file
/// </summary>
public static class WordList {
    static List<Word> s_WordList;

    public static void PopulateWords() {
        if (s_WordList != null)
            return;

        s_WordList = new List<Word>();

        // SHORT
        // ArtRelated
        s_WordList.Add(new Word("Musée", Word.e_WordCategories.SHORT_WORD, isArtRelated: true));
        s_WordList.Add(new Word("Danse", Word.e_WordCategories.SHORT_WORD, isArtRelated: true));
        s_WordList.Add(new Word("Dessin", Word.e_WordCategories.SHORT_WORD, isArtRelated: true));
        s_WordList.Add(new Word("Poésie", Word.e_WordCategories.SHORT_WORD, isArtRelated: true));
        s_WordList.Add(new Word("Emotif", Word.e_WordCategories.SHORT_WORD, isArtRelated: true));
        s_WordList.Add(new Word("Théâtre", Word.e_WordCategories.SHORT_WORD, isArtRelated: true));
        s_WordList.Add(new Word("Musique", Word.e_WordCategories.SHORT_WORD, isArtRelated: true));
        s_WordList.Add(new Word("Lecture", Word.e_WordCategories.SHORT_WORD, isArtRelated: true));
        s_WordList.Add(new Word("Créatif", Word.e_WordCategories.SHORT_WORD, isArtRelated: true));
        s_WordList.Add(new Word("Impulsif", Word.e_WordCategories.SHORT_WORD, isArtRelated: true));
        // !ArtRelated
        s_WordList.Add(new Word("Ponctuel", Word.e_WordCategories.SHORT_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Sport", Word.e_WordCategories.SHORT_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Ménage", Word.e_WordCategories.SHORT_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Fiable", Word.e_WordCategories.SHORT_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Précis", Word.e_WordCategories.SHORT_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Ordonné", Word.e_WordCategories.SHORT_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Logique", Word.e_WordCategories.SHORT_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Patient", Word.e_WordCategories.SHORT_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Sciences", Word.e_WordCategories.SHORT_WORD, isArtRelated: false));

        // MEDIUM
        // ArtRelated
        s_WordList.Add(new Word("Indépendant", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: true));
        s_WordList.Add(new Word("Sculpture", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: true));
        s_WordList.Add(new Word("Expressif", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: true));
        s_WordList.Add(new Word("Passionné", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: true));
        // !ArtRelated
        s_WordList.Add(new Word("Mécanique", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Rangement", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Habitudes", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Obéissant", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Routinier", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Rationnel", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Méthodique", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Synthétique", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Raisonnable", Word.e_WordCategories.MEDIUM_WORD, isArtRelated: false));

        // LONG
        // !ArtRelated
        s_WordList.Add(new Word("Informatique", Word.e_WordCategories.LONG_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Comptabilité", Word.e_WordCategories.LONG_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Mathématiques", Word.e_WordCategories.LONG_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Consciencieux", Word.e_WordCategories.LONG_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Travaux Manuels", Word.e_WordCategories.LONG_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Suivre les Règles", Word.e_WordCategories.LONG_WORD, isArtRelated: false));
        s_WordList.Add(new Word("Perfectionniste", Word.e_WordCategories.LONG_WORD, isArtRelated: false));
    }

    public static Word GetAWord() {
        if (s_WordList.Count < 1) {
            return null;
        }

        int rngIndex = Random.Range(0, s_WordList.Count);
        Word rngWord = s_WordList[rngIndex];
        s_WordList.RemoveAt(rngIndex);

        return rngWord;
    }
}
