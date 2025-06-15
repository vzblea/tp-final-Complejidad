
using System;
using System.Collections.Generic;
using tp1;
using tp2;

namespace tpfinal
{

	class Estrategia
	{
		public String Consulta1(ArbolBinario<DecisionData> arbol)
		{
			string result = " ";
			if(arbol.getHijoIzquierdo() == null && arbol.getHijoDerecho() == null) // si el nodo actual es hoja, imprime la prediccion.
                result += arbol.getDatoRaiz().ToString();
            if(arbol.getHijoIzquierdo() != null) // Si existe hijo izquierdo, se recorre recursivamente y se agrega su resultado.
                result += " " + Consulta1(arbol.getHijoIzquierdo());
            if(arbol.getHijoDerecho() != null) // Si existe hijo derecho, se recorre recursivamente y se agrega su resultado.
                result += " " + Consulta1(arbol.getHijoDerecho());
            return result;
		}


		public String Consulta2(ArbolBinario<DecisionData> arbol)
		{
			 string result = " ";
			 if(arbol.getHijoIzquierdo() != null || arbol.getHijoDerecho() != null) // Si el nodo NO es hoja (tiene una pregunta), se agrega su pregunta al resultado.
			 { 
                result += arbol.getDatoRaiz().ToString();
			 }
                
			 if(arbol.getHijoIzquierdo() != null) // Si existe hijo izquierdo, se realiza la consulta recursiva sobre él.
			 {
			 	result += " " + Consulta2(arbol.getHijoIzquierdo());
			 }
			 if(arbol.getHijoDerecho() != null) // Si existe hijo Derecho, se realiza la consulta recursiva sobre él tambien.
			 { 
                result += " " + Consulta2(arbol.getHijoDerecho());
			 }
            
            return result;
		}


		public String Consulta3(ArbolBinario<DecisionData> arbol)
		{
			string result = " ";
            Cola<ArbolBinario<DecisionData>> c = new Cola<ArbolBinario<DecisionData>>();
            ArbolBinario<DecisionData> arbolAux;
            c.encolar(arbol); //Encola el arbol
            while (!c.esVacia()){
                arbolAux = c.desencolar(); //Se almacena el arbol temporalmente.
                result += arbol.getDatoRaiz().ToString();
                if(arbolAux.getHijoIzquierdo()!= null){ // Si el nodo actual tiene hijo izquierdo, lo encola para procesarlo más adelante.
                    c.encolar(arbolAux.getHijoIzquierdo());
                }
                if(arbolAux.getHijoDerecho() != null){ // Si el nodo actual tiene hijo derecho, también se encola para recorrerlo después.
                    c.encolar(arbolAux.getHijoDerecho());
                }
            }
            return result;
		}

		public ArbolBinario<DecisionData> CrearArbol(Clasificador clasificador)
		{
			// Si es una hoja
		    if (clasificador.crearHoja())
		    {
		        var hoja = new DecisionData(clasificador.obtenerDatoHoja());
		        return new ArbolBinario<DecisionData>(hoja);
		    }
		
		    // Si es un nodo de decisión
		    var pregunta = clasificador.obtenerPregunta();
		    var nodo = new DecisionData(pregunta);
		    var arbol = new ArbolBinario<DecisionData>(nodo);
		
		    // Recursión para los hijos
		    var izquierdo = CrearArbol(clasificador.obtenerClasificadorIzquierdo());
		    var derecho = CrearArbol(clasificador.obtenerClasificadorDerecho());
		
		    arbol.agregarHijoIzquierdo(izquierdo);
		    arbol.agregarHijoDerecho(derecho);
		
		    return arbol;
		}
	}
}