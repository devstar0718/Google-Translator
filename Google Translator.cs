using Google.Api.Gax.ResourceNames;
using Google.Cloud.Translate.V3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleTranslator
{
    public partial class GoogleTranslator : Form
    {
        private Dictionary<string, string> LANG_ID;
        private List<string> AllOriginalText;
        private Dictionary<string, string> Dict_Target;

        public GoogleTranslator(string path)
        {
            InitializeComponent();
            LANG_ID = new Dictionary<string, string>();
            AddLanguages();
            AllOriginalText = new List<string>();
            textBoxSrc.Text = path;
            Dict_Target = new Dictionary<string, string>();
        }

        private void AddLanguages()
        {
            LANG_ID.Add("Afrikaans", "af");
            LANG_ID.Add("Albanian", "sq");
            LANG_ID.Add("Arabic", "ar");
            LANG_ID.Add("Armenian", "hy");
            LANG_ID.Add("Azerbaijani", "az");
            LANG_ID.Add("Basque", "eu");
            LANG_ID.Add("Belarusian", "be");
            LANG_ID.Add("Bengali", "bn");
            LANG_ID.Add("Bulgarian", "bg");
            LANG_ID.Add("Catalan", "ca");
            LANG_ID.Add("Chinese", "zh-CN");
            LANG_ID.Add("Croatian", "hr");
            LANG_ID.Add("Czech", "cs");
            LANG_ID.Add("Danish", "da");
            LANG_ID.Add("Dutch", "nl");
            LANG_ID.Add("English", "en");
            LANG_ID.Add("Esperanto", "eo");
            LANG_ID.Add("Estonian", "et");
            LANG_ID.Add("Filipino", "tl");
            LANG_ID.Add("Finnish", "fi");
            LANG_ID.Add("French", "fr");
            LANG_ID.Add("Galician", "gl");
            LANG_ID.Add("German", "de");
            LANG_ID.Add("Georgian", "ka");
            LANG_ID.Add("Greek", "el");
            LANG_ID.Add("Haitian Creole", "ht");
            LANG_ID.Add("Hebrew", "iw");
            LANG_ID.Add("Hindi", "hi");
            LANG_ID.Add("Hungarian", "hu");
            LANG_ID.Add("Icelandic", "is");
            LANG_ID.Add("Indonesian", "id");
            LANG_ID.Add("Irish", "ga");
            LANG_ID.Add("Italian", "it");
            LANG_ID.Add("Japanese", "ja");
            LANG_ID.Add("Korean", "ko");
            LANG_ID.Add("Lao", "lo");
            LANG_ID.Add("Latin", "la");
            LANG_ID.Add("Latvian", "lv");
            LANG_ID.Add("Lithuanian", "lt");
            LANG_ID.Add("Macedonian", "mk");
            LANG_ID.Add("Malay", "ms");
            LANG_ID.Add("Maltese", "mt");
            LANG_ID.Add("Norwegian", "no");
            LANG_ID.Add("Persian", "fa");
            LANG_ID.Add("Polish", "pl");
            LANG_ID.Add("Portuguese", "pt");
            LANG_ID.Add("Romanian", "ro");
            LANG_ID.Add("Russian", "ru");
            LANG_ID.Add("Serbian", "sr");
            LANG_ID.Add("Slovak", "sk");
            LANG_ID.Add("Slovenian", "sl");
            LANG_ID.Add("Spanish", "es");
            LANG_ID.Add("Swahili", "sw");
            LANG_ID.Add("Swedish", "sv");
            LANG_ID.Add("Tamil", "ta");
            LANG_ID.Add("Telugu", "te");
            LANG_ID.Add("Thai", "th");
            LANG_ID.Add("Turkish", "tr");
            LANG_ID.Add("Ukrainian", "uk");
            LANG_ID.Add("Urdu", "ur");
            LANG_ID.Add("Vietnamese", "vi");
            LANG_ID.Add("Welsh", "cy");
            LANG_ID.Add("Yiddish", "yi");

            for (int i = 0; i < LANG_ID.Count; i++)
                comboBoxLang.Items.Add(LANG_ID.ElementAt(i).Key);
        }



        private string GetFilePathWithOpenDialog()
        {
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "C:\\Surferbuddy";
                openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\Language";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }
            return filePath;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            textBoxSrc.Text = GetFilePathWithOpenDialog();
        }

        private void buttonTranslate_Click(object sender, EventArgs e)
        {
            if (textBoxSrc.Text == "" || comboBoxLang.Text == "" || textBoxDst.Text == "")
            {
                MessageBox.Show("Please select all the inputs.");
                return;
            }
                
            LoadTranslatedDataFromFile(textBoxDst.Text);
            LoadOriginalTextDataFromFile(textBoxSrc.Text);
            
            progressBar1.Minimum = 0;
            progressBar1.Maximum = AllOriginalText.Count;
            string lang = comboBoxLang.Text;
            string path = textBoxDst.Text;
            Task.Factory.StartNew(() => GenerateGoogleTranslationFile(lang, path));
            //GenerateGoogleTranslationFile(comboBoxLang.Text, textBoxPath.Text);
            progressBar1.Value = 0;
        }

        private void GenerateGoogleTranslationFile(string targetLang, string path)
        {
            if (AllOriginalText.Count == 0)
            {
                MessageBox.Show("No text to updates.");
                return;
            }
            //string file = Path.GetDirectoryName(path) + "/" + targetLang + ".txt";
            string file = path;
            //File.WriteAllText(file, string.Empty); // Clear content before writing
            
            for (int i = 0; i < AllOriginalText.Count; i++)
            {
                string orgText = AllOriginalText[i];
                using (StreamWriter sw = File.AppendText(file))
                {
                    sw.WriteLine("msgid:\t" + orgText.Trim());
                    string transText = "";
                    if (targetLang != "English")
                    {
                        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\translatorKey.json"))
                        {
                            transText = GoogleCloudTranslate(orgText, "English", targetLang);
                        }
                        else
                        {
                            transText = GoogleTranslate(orgText, "English", targetLang);
                        }

                    }
                    if (transText == "") continue;
                    //{
                    //    int counter = 100;
                    //    AddLog(string.Format("Too many request. Please wait for {0} secs...", counter));
                    //    for(int j = 0; j < counter; j ++)
                    //    {
                    //        if(j == 0)
                    //            AddLog(string.Format("\t\t{0} secs remaining...", counter - j));
                    //        else
                    //            UpdateLog(string.Format("\t\t{0} secs remaining...", counter - j));
                    //        Thread.Sleep(1000);
                    //    }
                    //    i--;
                    //    continue;
                    //}
                    sw.WriteLine("msgstr:\t" + transText.Trim());
                    sw.WriteLine("");
                    Invoke(new MethodInvoker(() => { progressBar1.Value++; }));//

                    string index = string.Format("({0} / {1})", i + 1, AllOriginalText.Count);
                    AddLog(string.Format("{0}\t  ->    {1}", index, orgText));
                    AddLog(string.Format("\t  <-    {0}", transText));
                    AddLog("");
                }
            }
            MessageBox.Show("Google Translation Finished");
        }

        private void AddLog(string text)
        {
            Invoke(new MethodInvoker(() =>
            {
                listBoxLog.Items.Add(text);
                //listBoxLog.Refresh();
                listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
            }));
        }
        private void UpdateLog(string text)
        {
            Invoke(new MethodInvoker(() =>
            {
                listBoxLog.Items[listBoxLog.Items.Count - 1] = text;
                //listBoxLog.Refresh();
            }));
        }

        private void LoadOriginalTextDataFromFile(string file)
        {
            try
            {
                string[] lines = File.ReadAllLines(file);
                string msgid;
                AllOriginalText.Clear();
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == "") continue;
                    if (lines[i].Substring(0, Math.Min(lines[i].Length, 6)) == "msgid:"
                        && i < lines.Length - 1
                        && lines[i + 1].Substring(0, Math.Min(lines[i + 1].Length, 7)) == "msgstr:")
                    {
                        msgid = lines[i].Substring(6).Trim();
                        //msgstr = lines[i + 1].Substring(7).Trim();
                        if(!Dict_Target.ContainsKey(msgid)) // Add if not exists in Tranlated Text.
                            AllOriginalText.Add(msgid);
                        continue;
                    }
                    //if (i > 50) break;
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(string.Format("Cannot read Translation file - {0}", e.FileName));
            }
        }

        private void LoadTranslatedDataFromFile(string file)
        {
            try
            {
                string[] lines = File.ReadAllLines(file);
                string msgid, msgstr;
                Dict_Target.Clear();
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == "") continue;
                    if (lines[i].Substring(0, Math.Min(lines[i].Length, 6)) == "msgid:"
                        && i < lines.Length - 1
                        && lines[i + 1].Substring(0, Math.Min(lines[i + 1].Length, 7)) == "msgstr:")
                    {
                        msgid = lines[i].Substring(6).Trim();
                        msgstr = lines[i + 1].Substring(7).Trim();
                        Dict_Target[msgid] = msgstr;
                        continue;
                    }
                    //if (i > 50) break;
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(string.Format("Cannot read Translation file - {0}", e.FileName));
            }
        }

        public string GoogleTranslate
                (string sourceText,
                 string sourceLanguage,
                 string targetLanguage)
        {
            // Initialize
            string translation = string.Empty;
            try
            {
                // Download translation
                string url = string.Format(
                //"https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
                "http://translate.google.com/translate_a/t?client=j&text={0}&hl=en&sl={1}&tl={2}&key={3}",
                 sourceText, LANG_ID[sourceLanguage], LANG_ID[targetLanguage],
                 "AIzaSyA_PFREI79cpD2UPJ6b0xCUFcxGJ1QxNyM");

                string outputFile = Path.GetTempFileName();
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                    wc.DownloadFile(url, outputFile);
                }

                // Get translated text
                if (File.Exists(outputFile))
                {

                    // Get phrase collection
                    string text = File.ReadAllText(outputFile);
                    int index = text.IndexOf(string.Format(",,\"{0}\"", LANG_ID[sourceLanguage]));
                    if (index == -1)
                    {
                        // Translation of single word
                        int startQuote = text.IndexOf('\"');
                        if (startQuote != -1)
                        {
                            int endQuote = text.IndexOf('\"', startQuote + 1);
                            if (endQuote != -1)
                            {
                                translation = text.Substring(startQuote + 1, endQuote - startQuote - 1);
                            }
                        }
                    }
                    else
                    {
                        // Translation of phrase
                        text = text.Substring(0, index);
                        text = text.Replace("],[", ",");
                        text = text.Replace("]", string.Empty);
                        text = text.Replace("[", string.Empty);
                        text = text.Replace("\",\"", "\"");

                        // Get translated phrases
                        string[] phrases = text.Split(new[] { '\"' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; (i < phrases.Count()); i += 2)
                        {
                            string translatedPhrase = phrases[i];
                            if (translatedPhrase.StartsWith(",,"))
                            {
                                i--;
                                continue;
                            }
                            translation += translatedPhrase + "  ";
                        }
                    }

                    // Fix up translation
                    translation = translation.Trim();
                    translation = translation.Replace(" ?", "?");
                    translation = translation.Replace(" !", "!");
                    translation = translation.Replace(" ,", ",");
                    translation = translation.Replace(" .", ".");
                    translation = translation.Replace(" ;", ";");

                    // And translation speech URL
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Return result
            return translation;
        }

        public string GoogleCloudTranslate(string sourceText,
                                           string sourceLanguage,
                                           string targetLanguage)
        {
            // Initialize
            try
            {
                //System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\karl6\OneDrive\Documents\translatorKey.json");
                System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\translatorKey.json");
                TranslationServiceClient client = TranslationServiceClient.Create();

                // Download translation
                TranslateTextRequest request = new TranslateTextRequest
                {
                    Contents = { sourceText },
                    TargetLanguageCode = LANG_ID[targetLanguage],
                    Parent = new ProjectName("natural-apricot-287217").ToString()
                };
                TranslateTextResponse response = client.TranslateText(request);
                Translation translation = response.Translations[0];
                return translation.TranslatedText;


                // Fix up translation
                //translation = translation.Trim();
                //translation = translation.Replace(" ?", "?");
                //translation = translation.Replace(" !", "!");
                //translation = translation.Replace(" ,", ",");
                //translation = translation.Replace(" .", ".");
                //translation = translation.Replace(" ;", ";");

                // And translation speech URL

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Return result
            return "";
        }

        private void buttonSelectDst_Click(object sender, EventArgs e)
        {
            textBoxDst.Text = GetFilePathWithOpenDialog();
        }
    }
}
