using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInstruction : MonoBehaviour
{
    Text text;
    Text bigText;
   // List<string> instructionsBigText = new List<string>();
    List<string> instructions = new List<string>();
    int index;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        //bigText = GetComponent<Text>();

        index = 0;






        //Prvá inštrukcia       
        instructions.Add("Pristál si na planéte Elektromagnetizmu, na ktorej upadli štátne železnice v zabudnutie. Tvojou úlohou je znovu naštartovať elektromotor opusteného vlaku a naladiť jeho parametre tak, aby bol schopný dopraviť ťa do druhej úrovne." +
            "\nPre ďalšie inštrukcie stlač tlačidlo 'Ďalej' v pravom dolnom rohu obrazovky...");

      
      //Informácie na úvod
        instructions.Add("Vlak, ktorý sa nachádza za východom má v sebe indukčný trojfázový synchrónny elektromotor poháňaný striedavým prúdom o výkone 6000 kW. Jeho účinnosť je pri vhodných otáčkach (1000 RPM) až 80%, to znamená, že ďalších 20% sa premení na teplo. ");

        //Prvá úloha
        
        instructions.Add("Tvojou prvou úlohou je preniesť akumulátory nachádzajúce sa na druhej strane miestnosti do vlaku. Tie mu budú slúžiť ako zdroj energie. Akumulátory postupne vlož do všetkých štyroch miest (minimálne do dvoch), ktoré sa nachádzajú na zadnej strane vlaku (po východe z miestnosti vľavo).");

        //drujá úloha
        instructions.Add("Tvojou druhou úlohou je naštartovať motor vlaku. To dosiahneš tak, že nastavíš otáčky motora tak, aby boli okolo 100 % otáčok motora (950 - 1050 RMP). Počet otáčok je 120 násobok frekvencie predelený počtom pólov, teda 120*f/p. Frekvencia by mala byť rovnaká ako je frekvencia siete.");
        
       //tretia úloha
        instructions.Add("Ak sa ti podarilo naštartovať motor, si už na polceste k úspešnému ukončeniu prvej úrovne. Tvojou úlohou je nastaviť počet pólov a frekvenciu tak, aby vlak dokázal dojsť ďalšej!");

        instructions.Add("Či si správne nastavil vstupné hodnoty tak, aby mal vlak čo najvyšší dojazd a dorazil do stanice (ktorá je podľa dostupných údajov vzdialená " +
            "približne 1300 km) si môžeš overiť tlačidlom 'Vypočítaj', ktoré sa nachádza na obrazovke s vstupnými hodnotami. Pozor! Toto tlačidlo vydrží už len niekoľko stlačení!");

        instructions.Add("Ak si správne naladil všetky údaje, odomkol sa ti v prednej časti vlaku teleport , ktorý ti umožní odísť. Gratulujem ! ");
    }

    public void nextInstruction()
    {
        if (index + 1 < instructions.Count)
            index++;
            
        text.text = instructions[index];       
        Debug.Log("index : " + index.ToString());       
    }

    public void previousInstruction()
    {
        if (index > 0)
            index--;

        text.text = instructions[index];
        //bigText.text = instructionsBigText[index];

        Debug.Log("index : " + index.ToString());
    }

}
