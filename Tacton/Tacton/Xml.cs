using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Tacton
{
    class Xml
    {
        private string nom;
        private XmlDocument docxml =  new XmlDocument();
        public void setNom(string nom)
        {
            this.nom = nom;
        }
        public void open()
        {
            this.docxml.Load(this.nom); 
        }
        public string readStatic()
        {
            XmlNode node = this.docxml.DocumentElement;
            
            string retour = "";

            XmlNode racine = node.SelectSingleNode("/TactonStatique");
            XmlAttributeCollection attributeCollection = racine.Attributes;
            string nbl = attributeCollection[2].Value;
            string nbc = attributeCollection[3].Value;

            XmlNodeList nodeList = node.SelectNodes("/TactonStatique/Motif/Ligne/Colonne");
            foreach (XmlNode nod in nodeList)
                retour+=nod.InnerText;
            return nbl+'#'+nbc+'#'+retour;
        }
        public void free()
        {
            this.docxml = new XmlDocument();
        }

        public void writeStatic(string tacton)
        {
            //1111,0000,1010,0010
            XmlDeclaration declaration = this.docxml.CreateXmlDeclaration("1.0", "utf-8", "");
            string[] tabTacton = tacton.Split(',');
            int nbl = tabTacton.Length;
            int nbc = tabTacton[0].Length;
            docxml.AppendChild(declaration);
            //creation de la racine
            XmlNode racine = docxml.CreateNode(System.Xml.XmlNodeType.Element, "TactonStatique","");
            
            //cr�ation des attributs pour la balise TactonStatique
            XmlAttribute auteur = docxml.CreateAttribute("auteur");
            auteur.Value="Dupire";
            racine.Attributes.Append(auteur);
            XmlAttribute date = docxml.CreateAttribute("date");
            date.Value=DateTime.Now.ToString();
            racine.Attributes.Append(date);
            XmlAttribute nbligne = docxml.CreateAttribute("nbligne");
            nbligne.Value=nbl.ToString();
            racine.Attributes.Append(nbligne);
            XmlAttribute nbcolonne = docxml.CreateAttribute("nbcolonne");
            nbcolonne.Value=nbc.ToString();
            racine.Attributes.Append(nbcolonne);

            XmlNode motif = docxml.CreateElement("Motif");
            for (int i = 1; i <nbl+1 ; i++)
            {
                XmlNode ligne = docxml.CreateElement("Ligne");
                XmlAttribute numeroLigne = docxml.CreateAttribute("numero");
                numeroLigne.Value = i.ToString();
                ligne.Attributes.Append(numeroLigne);
                for(int j = 1;j<nbc+1;j++)
                {
                    XmlNode colonne = docxml.CreateElement("Colonne");
                    XmlAttribute numeroColonne = docxml.CreateAttribute("numero");
                    numeroColonne.Value = j.ToString();
                    colonne.Attributes.Append(numeroColonne);
                    colonne.InnerText = tabTacton[i - 1].Substring(j - 1, 1);
                    ligne.AppendChild(colonne);
                }
                motif.AppendChild(ligne);
            }
            racine.AppendChild(motif);
            docxml.AppendChild(racine);
            docxml.Save(this.nom);
        }
        public string readDynamique()
        {
            string retour = "";
            XmlNode node = this.docxml.DocumentElement;
            XmlNode racine = node.SelectSingleNode("/TactonDynamique");
            XmlAttributeCollection attributeCollection = racine.Attributes;
            string auteur = attributeCollection[0].Value;
            string date = attributeCollection[1].Value;
            int tailleMatriceLigne = Convert.ToInt32(attributeCollection[2].Value);
            int tailleMatriceColonne = Convert.ToInt32(attributeCollection[3].Value);
            int nombreTacton = Convert.ToInt32(attributeCollection[4].Value);
            double uniteTemps = Convert.ToDouble(attributeCollection[5].Value);
            retour += tailleMatriceLigne.ToString() + "#" + tailleMatriceColonne.ToString() + "#" + nombreTacton.ToString() + "#" + uniteTemps.ToString() + "#";

            XmlNodeList nodeList = node.SelectNodes("/TactonDynamique/Image");
            bool firstOne = true;
            foreach (XmlNode nod in nodeList)
            {
                if (firstOne)
                {
                    firstOne = false;
                    retour += nod.SelectSingleNode("Duree").InnerText.Substring(1, nod.SelectSingleNode("Duree").InnerText.Length - 1);
                }
                else
                    retour += nod.SelectSingleNode("Duree").InnerText;
                retour += nod.SelectSingleNode("Motif").InnerText;
            }
            return retour;
        } // taille matrice, nombre tacton, unite de temps

        public void writeDyanique(string tacton)
        {
            //auteur#nbLigne#nbColonne#nbImage#uniteTemps#10 0101010111001010 10 0000111100001111 
            string[] detailsTacton = tacton.Split('#');
            XmlDeclaration declaration = this.docxml.CreateXmlDeclaration("1.0", "utf-8", "");
            docxml.AppendChild(declaration);
            //creation de la racine
            XmlNode racine = docxml.CreateNode(System.Xml.XmlNodeType.Element, "TactonDynamique", "");
            XmlAttribute auteur = docxml.CreateAttribute("auteur");
            int nbLigne = Convert.ToInt32(detailsTacton[1]);
            int nbColonne = Convert.ToInt32(detailsTacton[2]);
            int nbImages = Convert.ToInt32(detailsTacton[3]);
            auteur.Value = detailsTacton[0];
            racine.Attributes.Append(auteur);
            XmlAttribute date = docxml.CreateAttribute("date");
            date.Value = DateTime.Now.ToString();
            racine.Attributes.Append(date);
            XmlAttribute nbligne = docxml.CreateAttribute("nbligne");
            nbligne.Value = nbLigne.ToString();
            racine.Attributes.Append(nbligne);
            XmlAttribute nbcolonne = docxml.CreateAttribute("nbcolonne");
            nbcolonne.Value = nbColonne.ToString();
            racine.Attributes.Append(nbcolonne);
            XmlAttribute nbimage = docxml.CreateAttribute("nbImages");
            nbimage.Value = nbImages.ToString();
            racine.Attributes.Append(nbimage);
            XmlAttribute uniteTemps = docxml.CreateAttribute("uniteTemps");
            uniteTemps.Value = detailsTacton[4];
            racine.Attributes.Append(uniteTemps);

            string[] detailsImage = detailsTacton[5].Split(' ');
            for (int i = 0; i < nbImages; i++)
            {
                XmlNode nodeImage = docxml.CreateElement("Image");
                XmlAttribute numeroImage = docxml.CreateAttribute("numero");
                numeroImage.Value = (i+1).ToString();
                nodeImage.Attributes.Append(numeroImage);
                XmlNode nodeDuree = docxml.CreateElement("Duree");
                nodeDuree.InnerText = " "+detailsImage[i * 2]+" ";
                nodeImage.AppendChild(nodeDuree);
                XmlNode nodeMotif = docxml.CreateElement("Motif");
                for (int j = 0; j < nbLigne; j++)
                {
                    XmlNode nodeLigne = docxml.CreateElement("Ligne");
                    XmlAttribute numero = docxml.CreateAttribute("numero");
                    numero.Value = (j+1).ToString();
                    nodeLigne.Attributes.Append(numero);
                    for(int k = 0;k<nbColonne;k++)
                    {
                        XmlNode nodeColonne = docxml.CreateElement("Colonne");
                        XmlAttribute numeroColonne = docxml.CreateAttribute("numero");
                        numeroColonne.Value = (k + 1).ToString();
                        nodeColonne.Attributes.Append(numeroColonne);
                        int tmp = (j * nbColonne) + k;
                        nodeColonne.InnerText= detailsImage[(i*2)+1].Substring(tmp, 1);
                        nodeLigne.AppendChild(nodeColonne);
                    }
                    nodeMotif.AppendChild(nodeLigne);
                }
                nodeImage.AppendChild(nodeMotif);
                racine.AppendChild(nodeImage);
            }
            docxml.AppendChild(racine);
            docxml.Save(this.nom);

        }

    }
}
