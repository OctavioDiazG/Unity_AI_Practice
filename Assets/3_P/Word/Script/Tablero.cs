using System;
using System.Text;
using System.Globalization;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tablero : MonoBehaviour
{
    public Fila[] filas;
    public String palabraRamdom;
    public String palabraActual = "cacas";
    private int filaActual = 0;
    public GameObject canvasFinal;
    public Text mensaje;
    
    public string[] verdaderasPalabras;
    public string[] palabras = new string[]
    {
        "aboya", "abran", "abras", "abria", "acles", "acoja", "acojo", "acres",
        "actas", "actos", "actuo", "acuna", "acune", "acuno", "acuso", "afeas", "afijo",
        "aguda", "agudo", "alaju", "Aland", "albas", "albos", "alces", "Aldea", "aleja", 
        "algas", "alhaju", "alias", "almas", "alojo", "aloja", "alojo", "altar", "altas",
        "altos", "alias", "amina", "amina", "ancas", "andas", "andes", "andes", "anear", "anima",
        "animo", "anima", "animo", "aojar", "aojas", "aojos", "aojas", "apees", "apees", "apoda",
        "apodo", "apoda", "apodo", "aptas", "aptos", "aptas", "apure", "arces", "arcos", "ardan",
        "ardas", "ardes", "ardas", "ardes", "arias", "arios", "arlas", "arlos", "arlas", "armes",
        "armes", "arpas", "artes", "Aruba", "arune", "aruno", "arune", "aruno", "areis", "asate",
        "ascos", "asees", "aseos", "asida", "asido", "asilo", "asire", "asnos", "asolo", "aspee",
        "aspee", "aseis", "asian", "asias", "atoja", "atojo", "atoja", "atojo", "auras", "autos",
        "avale", "avara", "ayuda", "azote", "aerea", "anoro", "anoro", "babeo", "bacan", "bagas", "baile",
        "bagas", "bajas", "bajes", "bajos", "bajas", "bajes", "bajos",
        "balas", "bales", "balas", "bales", "bares", "barre", "barra", "barre", "basca", "basca",
        "baste", "basta", "baste", "batas", "bates", "batea", "batas", "batis", "bayas", "banas",
        "banes", "Banos", "banes", "bebed", "bebes", "Benin", "besen", "beses",
        "besos", "betas", "bizco", "bizco", "bodas", "bogad", "bogas", "bogue", "bogue",
        "bogas", "bojar", "bojas", "bojos", "bojas", "bolar", "bolla", "bondi", "bonos", "borre",
        "borre", "boses", "boses", "botad", "botan", "botas", "boten", "botes", "botas", "botes",
        "boyas", "boyas", "bozos", "bramo", "bramo", "Bruno", "bruta", "bruno", "bruño", "bruño",
        "brios", "bulas", "bulos", "busca", "busco", "buses", "Butan", "cabra", "caceo", "caces",
        "cacho", "caces", "cafes", "cagas", "cagas", "cajas", "calce", "calce", "calco", "cales",
        "callo", "callo", "calme", "calmo", "calme", "calmo", "cales", "campo", "canas", "canes",
        "canos", "cansa", "cansa", "canta", "canto", "capas", "capen", "capes", "cappa", "capta",
        "capto", "capta", "capto", "capas", "capes", "carga", "cargo", "Carla", "caros", "casad",
        "casan", "casas", "casca", "casca", "casco", "casen", "cases", "casos", "casas", "cases",
        "Catar", "catas", "catas", "cause", "cause", "cavas", "cavos", "cazad", "cazan", "cazas",
        "cazos", "caida", "caido", "cañas", "cañeo", "caños", "cañas", "cañis", "cebos", "cedan",
        "cedas", "ceded", "ceden", "cedes", "cedas", "cedes", "cefos", "cejas", "cejas", "celes",
        "Celia", "celta", "cenas", "cepas", "ceras", "cerca", "cerco", "cerdo", "ceros", "cerrá",
        "cerro", "chefs", "Chile", "China", "chiis", "choco", "chuzá", "ciega", "cimas", "cimas",
        "cines", "citas", "citas", "clamo", "clamo", "Clara", "clava", "clava", "clave", "clavo",
        "clubs", "coces", "coces", "codeo", "codos", "coged", "cogen", "coger", "coges", "coges",
        "cogia", "cojan", "cojas", "cojos", "cojas", "colas", "coles", "colma", "colma", "colas",
        "colon", "coman", "comas", "combo", "comed", "comes", "comas", "comes", "conos", "copas",
        "copos", "copta", "copas", "coral", "coras", "Corea", "corea", "corea", "corra", "corre",
        "corro", "corre", "corri", "corsa", "cosas", "coses", "coste", "coste", "costo", "cosas",
        "coses", "coños", "crasa", "creas", "crees", "creme", "cremo", "creme", "cremo", "crees",
        "croar", "cruje", "crien", "cubas", "cubos", "cucas", "cucos", "cucas", "cuida", "cuide",
        "cuida", "cuide", "culos", "culta", "cunas", "cunas", "cupos", "cural", "curas", "curdo",
        "cures", "curio", "curro", "curso", "curas", "cures", "cuñas", "cuñas", "dados", "dagas",
        "dance", "dance", "dando", "danos", "Dario", "datos", "dañes", "daños", "dañes", "debas",
        "debed", "deben", "debes", "debés", "dedos", "dejas", "dejas", "densa", "deseo", "dices",
        "dijes", "diles", "divas", "divos", "doble", "dolos", "doman", "domas", "domes", "domos",
        "domas", "domes", "donan", "donas", "donen", "dones", "donas", "dones", "dores", "doria",
        "dorio", "dotas", "dotes", "dotas", "dotes", "doñas", "drunk", "drupa", "Dubai", "Dubai",
        "dudan", "dunas", "dures", "duros", "dures", "diver", "duhos", "echas", "eches",
        "echos", "eches", "edita", "edita", "eleve", "eleve", "ellos", "emana", "emana", "emoji",
        "emoyi", "emula", "emule", "emulo", "emula", "emule", "emulo", "emues", "enoja", "enojo",
        "enoja", "enes", "envio", "erizo", "errar", "erres", "erres", "espia", "espia", "estad",
        "estas", "euros", "evita", "evita", "expansionar", "expia", "faces", "falle", "falle",
        "falos", "falta", "fases", "ferio", "fetos", "ficad", "ficas", "ficas", "fijas", "fijas",
        "filas", "files", "filas", "filin", "finco", "finco", "fines", "fique", "fique", "firme",
        "floto", "focos", "folia", "folia", "folla", "follo", "follo", "fomes", "force", "forme",
        "formo", "forma", "forme", "formo", "fosos", "fotos", "Frida", "frita", "frita", 
        "frias", "fugas", "fugue", "fugue", "fugas", "fumes", "fumes", "fusil", "Gabon", "gafas",
        "galas", "Gales", "Galia", "galos", "Galan", "ganes", "ganas", "ganes", "gases", "gasto",
        "gatos", "genes", "gerbo", "Ghana", "gimen", "gimes", "giras", "giros", "giras", "godas",
        "godos", "goles", "gorda", "gorra", "grave", "grave", "grave", "grave", "grite", "grite",
        "grite", "grito", "groar", "gruas", "gurus", "guera", "habas", "habed", "hablas", "habla", "hablás", 
        "habrá", "habré", "había", "hacen", "haces", "hacha", "hacés", "hacía",
        "hagan", "hagas", "hagás", "Haití", "halan", "halas", "hallo", "hallá", "halos", "halás", "harte",
        "harán", "harás", "haría", "hastío", "Hawái", "hayan", "hayas", "hayás", "heces", "hecha", "hecho",
        "hemos", "hiero", "higos", "hijas", "hijos", "hilan", "hilos", "hinca", "hinco", "hincó", "hipos",
        "hitos", "hoces", "hocés", "hojas", "horne", "horné", "huera", "huero", "hunas", "hunos", "hurgo",
        "husos","ibais", "ideas", "ideás", "iglús", "India", "infle", "inflé", "intis", "iréis", "irían", "irías",
        "isbas", "islas", "Ivana", "Jabes", "jadee", "jadeo", "jades", "jadeé", "Jairo", "jalan",
        "jalón", "Japón", "jefes", "jemal", "jemes", "jerbo", "jerga", "Jesús", "jodas", "jodes", "jodás",
        "jodés", "jonia", "joyas", "joyel", "jugos", "jujeo", "Julio", "jures", "jurés", "Kabul", "kanes",
        "Kenia", "kunas", "kurda", "labes", "labia", "labra", "labre",  "lacra", "lacta",
        "lactá", "lados", "ladro", "ladró", "Lagos", "lagos", "lamas", "lamen", "lames", "lamió", "lamás",
        "lamés", "lancé", "lapas", "larga", "larva", "latas", "latás", "laves", "lavés", "laxas", "laxos",
        "laxás", "lazan", "lazos", "legas", "legos", "lejos", "lemas", "lenta", "levas", "leves", "levás",
        "levés", "leyes", "leías", "Libia", "libia", "libré", "libró", "licua", "licuá", "licúa", "lides",
        "limas", "linda", "liras", "lises", "locas", "locha", "locos", "locus", "logró", "lomos", "lores",
        "loros", "losas", "losás", "loteo", "lotes", "lozas", "luces", "luche", "Lucho", "lucho", "luchá",
        "luché", "luchó", "lulos", "lunas", "lusas", "lusos", "líber", "Macao", "maceo", "magos", "Maine",
        "malas", "males", "malos", "Malta", "malís", "mamas", "mamás", "manas", "manca", "mancá", "mancó",
        "manda", "mandó", "mangó", "manos", "manás", "mapas", "marcó", "mares", "marro", "Marín", "masco", "mases",
        "matas", "mates", "mayas", "mayás", "mazos", "mañas", "meaba", "mecen",
        "meces", "mecés", "mediá", "memes", "menes", "mentá", "menés", "menús", "meras", "merco", "mercó",
        "mermo", "meros", "merás", "mesas", "mesen", "meses", "mesás", "mesés", "metas", "metes",
        "metás", "mezas", "mezás", "micas", "midas", "midás", "migro", "miles", "minas", "mines", "Minsk",
        "minás", "minés", "miras", "miren", "mires", "mirás", "mirés", "misad", "misas", "misma", "mista",
        "mistá", "misás", "mitos", "mitro", "mitró", "mocos", "modas", "modos", "mofas", "mofes", "mofás",
        "mofés", "mojan", "mojar", "mojas", "mojen", "mojos", "mojás", "molas", "moles", "molás", "molés",
        "monas", "monos", "monté", "montó", "mopas", "moras", "mores", "moros", "morro", "morás", "morés",
        "Moscú", "motas", "motes", "moved", "mozas", "moños", "mucas", "mucos", "mudas", "mudos", "mudás",
        "mueve", "mugen", "muges", "mugid", "mugió", "mugís", "mujan", "mujas", "mulas", "mulos", "multe",
        "multá", "multé", "muros", "musas", "musás", "mutar", "mutas", "nabos", "naces", "nacés", "nadas",
        "nades", "nadés", "narre", "narré", "natas", "natos", "Nauru", "Naurú", "naves", "nazca", "nazis",
        "necia", "necio", "Nepal", "netos", "nexos", "niños", "nomos", "notas", "notes", "notás", "notés",
        "nubes", "nucas", "nudas", "nudos", "nulas", "nulos", "Níger", "obras", "odias", "odios", "odiás",
        "odres", "ogros", "ollas", "omaní", "ombús", "ondas", "onzas", "opera", "operá", "optas", "optás",
        "orbes", "orcas", "orden", "oriná", "ornan", "ornee", "orneé", "ortos", "oseas", "oseás", "osito",
        "otras", "ovulo", "ovuló", "oírte", "pacas", "pacen", "pacta", "pactá", "pactó", "pacés", "pagan",
        "pague", "pagué", "pajas", "pajes", "palas", "palme", "palmá", "palmé", "palos", "palpa", "panes", "papúa", "papús", "paras",
        "parda", "Pardo", "paree", "paren", "pares", "pareé", "parta", "partí", "parás", "paría", "París", "parís",
        "pasas", "pasen", "pases", "paseó", "pasás", "pasés", "patas", "patea", "pateá", "patos", "patés", "pavos",
        "pañal", "pecas", "peces", "pecio", "pedos", "pegas", "pegue", "pelis", "pelos", "penan", "penas", "penda",
        "pende", "penen", "penes", "pensá", "pensé", "penás", "penés", "peras", "perdí", "peros", "pesad", "pesas",
        "pescá", "pesen", "peses", "pesos", "pesás", "pesés", "petas", "petos", "petás", "peáis", "peñas", "pican",
        "picas", "pichá", "picos", "picás", "pidas", "pides", "pidás", "pifie", "pines", "pipas", "pisad", "piscó",
        "pises", "pitan", "pitos", "pizco", "pizcó", "planta", "playá", "plena", "pleno", "pobló", "pocas", "pocos",
        "podas", "poded", "poder", "podes", "podrá", "podré", "podáis", "podás", "podés", "podía", "polos", "poned",
        "ponen", "poner", "pones", "ponga", "ponés", "ponía", "porfa", "poros", "posas", "posee", "posen", "poses",
        "poseé", "posos", "posás", "posés", "potos", "poyas", "poyás", "pozos", "Prada", "prado", "prevé", "preña",
        "preño", "preñá", "preñó", "primó", "probó", "pueda", "puede", "puedo", "pujan", "pujas", "pujen", "pujás",
        "pulen", "pulsa", "pulsá", "pumas", "puras", "purgá", "puros", "putas", "Qatar", "quede", "quedé", "queme",
        "quemo", "quemá", "quemé", "quemó", "quepa", "queré", "quise", "quiso", "Quito", "quito", "quitó", "Rabat",
        "rabeo", "rabiá", "rabos", "rabón", "ralbe", "ralbé", "ramos", "ranas", "rapas", "rapás", "raras", "raros",
        "rasas", "rasco", "rascá", "raspá", "rasás", "ratas", "ratos", "razas", "razás", "raéis", "reces", "recia",
        "recio", "recés", "redes", "regia", "regía", "reinó", "rejas", "remas", "remes", "remos", "remás", "remés", 
        "renos", "rento", "rentá", "rentó", "reses", "reste", "resté", "restó",
        "retes", "retos", "retés", "reyes", "rezan", "rezas", "rezás", "reíos", "reúna", "rices", "rifas", "rimas",
        "rimen", "rimes", "rimás", "rimés", "rinda", "ritos", "roban", "robes", "robés", "rocas", "rodas", "rodás",
        "rojas", "rojos", "roles", "rolla", "rollá", "rolló", "romas", "romos", "rompa", "rompe", "rompé", "rondó",
        "rones", "rotas", "rotos", "rotás", "royas", "royos", "royás", "rubís", "rudos", "rueis", "rugen", "ruges",
        "rugió", "rugís", "rujan", "rulos", "runas", "rusas", "Rusia", "rusos", "rutas", "ruéis", "ruñas", "ruñás",
        "sabia", "sabía", "sacan", "sacas", "sacos", "sacra", "sacás", "sajón", "sakes", "saldó", "salga", "salgo",
        "salgá", "salgó", "salta", "saltá", "saltó", "salud", "salva", "salve", "salvá", "salvé", "salvó", "salís",
        "Samoa", "sanad", "sanas", "sanos", "santa", "sanás", "sapos", "saudí", "sañas", "sebos", "secan", "sedad",
        "sedan", "sedas", "seden", "sedes", "sedás", "sedés", "sentá", "senté", "sentó", "sepas", "sepás", "seres",
        "seria", "seriá", "serró", "serán", "serás", "sería", "setas", "setos", "sexos", "señás", "siega", "siego",
        "sigan", "Siria", "siria", "siseo", "sitúo", "soban", "sobas", "sobes", "sobré", "sobés", "sodas", "sogas",
        "Solas", "solas", "soles", "solos", "solés", "solía", "somos", "sonad", "sonar", "sondá", "sonás", "sopas",
        "soplo", "sopló", "sopás", "sorbe", "sorbé", "soñad", "soñar", "soñás", "soñés", "subas", "subes", "sucia",
        "sucre", "sudan", "sudar", "sudas", "sudes", "Sudán", "sudás", "sudés", "suela", "suele", "suena", "suene",
        "sueno", "sueña", "sueñe", "sueño", "Suiza", "suiza", "sumas", "sumás", "supón", "suras", "sushi", "sáxeo",
        "súper", "tabas", "tabús", "tacos", "talas", "tales", "talás", "talés", "tapas", "tapen", "tapes", "tapás", 
        "tapés", "tardé", "Tegus", "Tejas", "tejas", "telas", "temas", "temen",
        "temes", "temás", "temés", "tened", "tenga", "tengo", "tenia", "tensa", "tensá", "tensó", "tenés", "tenía",
        "terca", "tersa", "terse", "tersá", "tersé", "tersó", "testo", "testá", "testó", "tetar", "tetas", "tetás",
        "Texas", "teñía", "tiene", "times", "timés", "tipos", "tiras", "tiros", "tirás", "tisús", "titán", "tocás",
        "todas", "todos", "togas", "togás", "tomad", "toman", "tomas", "tomes", "tomás", "tomés", "Tonga", "tonos",
        "tonta", "topas", "topos", "topás", "toqué", "torpe", "tosed", "toses", "traed", "traen", "traer", "traes",
        "tragá", "trajo", "tramá", "trató", "traés", "traía", "trinó", "trocó", "tronó", "troté", "tríos", "tubos",
        "Tulio", "tumbá", "tunas", "tunás", "tólar", "Túnez", "ubres", "untes", "unías", "urbes", "urdas",
        "Uribe", "urnas", "usaos", "usate", "uséis", "uñoso", "vacan", "vacas", "vados", "vagas", "vagos", "vague",
        "vagué", "vagás", "vales", "valga", "valgo", "valla", "valsa", "valse", "valsá", "valsé", "valés", "vamos",
        "vanos", "vasca", "vasos", "vasta", "vates", "vayan", "vayas", "vayás", "veces", "vecés", "vedas", "velas",
        "velen", "veles", "velos", "velás", "velés", "vemos", "venas", "vendé", "vengo", "vengó", "vente", "venté",
        "Verde", "veros", "verás", "veréis", "vería", "vetas", "vetos", "veían", "veías", "viajé", "vidas", "viene",
        "viera", "vigas", "viles", "vinos", "vires", "visco", "viste", "vivás", "voces", "volar", "volví", "volás",
        "votad", "votan", "votar", "votas", "voten", "votes", "votos", "votás", "votés", "vudús", "vídeo", "wikis",
        "wones", "yates", "yemas", "Yemen", "yendo", "yenes", "yesca", "yogur", "yugos", "zacas", "zarca", "zares",
        "zedas", "zetas", "zonas", "zorro", "zulús", "zurda", "zurro"
    };

    public List<char> letraDescartadas;
    public List<char> letrasUtiles;
    public List<int> posciones;
    private void Awake()
    {
        for (int i = 0; i < palabras.Length; i++)
        {
            palabras[i] = RemoveAccentsAndToUpper(palabras[i]);
        }
        verdaderasPalabras = RemoveDuplicates(palabras);
        int indiceAleatorio = UnityEngine.Random.Range(0, verdaderasPalabras.Length);
        palabraRamdom = verdaderasPalabras[indiceAleatorio];
        filas = GetComponentsInChildren<Fila>();

        for (int i = 0; i < 5; i++)
        {
            posciones.Add(5);
            letrasUtiles.Add(' ');
        }
    }

    public void checarVictoria(int _puntos)
    { 
        if (filaActual > 5)
        {
            mostrarUI("Perdio");
        }
        if (_puntos == 5)
        {
            mostrarUI("Ganaste");
        }
    }
    private string RemoveAccentsAndToUpper(string input)
    {
        string normalized = input.Normalize(NormalizationForm.FormD);
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        string result = stringBuilder.ToString().ToUpper();
        return result;
    }
    
    private string[] RemoveDuplicates(string[] words)
    {
        HashSet<string> uniqueSet = new HashSet<string>(words);
        string[] uniqueWords = new string[uniqueSet.Count];
        uniqueSet.CopyTo(uniqueWords);
        return uniqueWords;
    }

    public void mostrarUI(String _mensaje)
    {
        canvasFinal.SetActive(true);
        mensaje.text = "" + _mensaje;
        Time.timeScale = 0f;
    }

    public void volverAEmpezar(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public bool comprobarLista()
    {
        for (int i = 0; i < verdaderasPalabras.Length; i++)
        {
            if (palabraActual == verdaderasPalabras[i])
            {
                return true;
            }
        }
        return false;
    }

    public void subirPalabra()
    {
        verdaderasPalabras = verdaderasPalabras.Where(p => !p.Any(c => letraDescartadas.Contains(c))).ToArray();
        for (int i = 0; i < 5; i++)
        {
            if (posciones[i] != 5)
            {
                verdaderasPalabras = verdaderasPalabras.Where(p => p.Length > posciones[i] && p[posciones[i]] == letrasUtiles[i]).ToArray();
            }
            else
            {
                if (letrasUtiles[i] != ' ')
                {
                    verdaderasPalabras = verdaderasPalabras.Where(p => p.Any(c => letrasUtiles.Contains(c))).ToArray();
                }
            }
        }
        
        int indiceAleatorio = UnityEngine.Random.Range(0, verdaderasPalabras.Length);
        palabraActual = verdaderasPalabras[indiceAleatorio];
        int puntos = 0;
        bool existe = comprobarLista();
        if (existe)
        {
            for (int i = 0; i < filas[filaActual].celdas.Length; i++)
            {
                filas[filaActual].word[i] = palabraActual[i];
                filas[filaActual].cambiarLetra(i);
                if (filas[filaActual].word[i] == palabraRamdom[i])
                {
                    puntos++;
                    filas[filaActual].celdas[i].correcta();
                    letrasUtiles[i] = palabraActual[i];
                    posciones[i] = i;
                    //posciones.Add(i);
                }
                else
                {
                    filas[filaActual].celdas[i].incorrecta();
                    
                    for (int j = 0; j < filas[filaActual].celdas.Length; j++)
                    {
                        if (filas[filaActual].word[i] == palabraRamdom[j])
                        {
                            filas[filaActual].celdas[i].semiCorrecta();
                            
                        }
                    }

                    if (filas[filaActual].celdas[i].util)
                    {
                        //letrasUtiles[i] = palabraActual[i];
                    }
                    else
                    {
                        letraDescartadas.Add(palabraActual[i]);
                    }
                }
            }
            letraDescartadas = letraDescartadas.Distinct().ToList();
            //letrasUtiles = letrasUtiles.Distinct().ToList();


            filaActual++;
            checarVictoria(puntos);
        }
        else
        {
            Debug.Log("no existe");
        }
    }
}
