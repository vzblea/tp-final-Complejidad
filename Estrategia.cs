
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
			if(arbol.getHijoIzquierdo() == null && arbol.getHijoDerecho() == null)
                result += arbol.getDatoRaiz().ToString();
            if(arbol.getHijoIzquierdo() != null)
                result += " " + Consulta1(arbol.getHijoIzquierdo());
            if(arbol.getHijoDerecho() != null)
                result += " " + Consulta1(arbol.getHijoDerecho());
            return result;
		}

		public String Consulta2(ArbolBinario<DecisionData> arbol)
		{
			string result = " ";
			if(arbol.getHijoIzquierdo() != null || arbol.getHijoDerecho() != null)
			{ 
                result += arbol.getDatoRaiz().ToString();
			}
			if(arbol.getHijoIzquierdo() != null)
			{
			 	result += " " + Consulta2(arbol.getHijoIzquierdo());
			}
			if(arbol.getHijoDerecho() != null)
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
            c.encolar(arbol);
            while (!c.esVacia()){
                arbolAux = c.desencolar();
                result += arbol.getDatoRaiz().ToString();
                if(arbolAux.getHijoIzquierdo()!= null){
                    c.encolar(arbolAux.getHijoIzquierdo());
                }
                if(arbolAux.getHijoDerecho() != null){
                    c.encolar(arbolAux.getHijoDerecho());
                }
            }
            return result;
		}

		public ArbolBinario<DecisionData> CrearArbol(Clasificador clasificador)
		{
		    if (clasificador.crearHoja())
		    {
		        var hoja = new DecisionData(clasificador.obtenerDatoHoja());
		        return new ArbolBinario<DecisionData>(hoja);
		    }
		
		    var pregunta = clasificador.obtenerPregunta();
		    var nodo = new DecisionData(pregunta);
		    var arbol = new ArbolBinario<DecisionData>(nodo);
		
		    var izquierdo = CrearArbol(clasificador.obtenerClasificadorIzquierdo());
		    var derecho = CrearArbol(clasificador.obtenerClasificadorDerecho());
		
		    arbol.agregarHijoIzquierdo(izquierdo);
		    arbol.agregarHijoDerecho(derecho);
		
		    return arbol;
		}
	}
}
