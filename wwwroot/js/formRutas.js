(() => {
    document.addEventListener('DOMContentLoaded', () => {
        let form = document.querySelector("#form-ruta");
        let contentParadas = document.querySelector("#contentParadas");
        let btnAgregarParada = document.querySelector("#btn-agregar-parada");

        let paradas = [];
        let paradasUsadas = [];
        let paradasParaUsar = []
        let paradasRuta = [];

        //obtiene las paradas que existen en la base de datos
        let getParadas = async () => {
           paradas = await fetch("/paradas/GetParadas").then(res => res.json()); 
           filtrarParadasNoUsadas();  
        }

        // muestra las paradas que se van a agregar a la ruta
        let mostrarParadasRuta = () => {
            contentParadas.innerHTML = "";

            paradasRuta.forEach(parada => {
                contentParadas.appendChild(parada);
            });
        };        

        // crea el elemento option para que se seleccionen las rutas 
        // recibe dos parametros, value y text 
        // value = el valor que se enviara 
        // text = texto a mostrar
        let crearOptionParada = (value,text) => {
            let option = document.createElement("option");
            option.value = value;
            option.text = text;

            return option;
        }

        // crea el select para cada nueva parada
        // recibe un parametro, options
        // options = arreglo de opciones que se van a crear con el select
        let createSelectParada = (options) => {
            let select = document.createElement("select");
            select.name = "Paradas[]";

            let optionDefault = document.createElement("option");
            optionDefault.value = "";
            optionDefault.text = "-- Selcciona la parada --";

            select.options.add(optionDefault);
            options.forEach(option => {
                select.options.add(crearOptionParada(option.idParada,option.nombreParada));
            });

            return select;
        }

        // filtra todas las paradas que no se han usado para que no haya repeticiones
        let filtrarParadasNoUsadas = () => {
            if(paradasUsadas.length != 0) {
                let paradasFiltradas = [];
                paradas.forEach(p => {
                    paradasUsadas.forEach(pu => {
                        if(p.id != pu.id) paradasFiltradas.push(p);
                    });
                });
                paradasParaUsar = paradasFiltradas;
            }else{
                paradasParaUsar = paradas;
            }
        }

        // crea un nuevo elemento, que contiene un select y un boton 
        // el select muestra las paradas que se pueden agregar 
        // el boton elimina el elemento completo
        let agregarParada = () => {
            let id =  Math.random().toString(36).substring(2);
            let parada = document.createElement("P");
            parada.setAttribute("id",id);
            
            parada.appendChild(createSelectParada(paradasParaUsar));
            
            let btnEliminar = document.createElement("button");
            btnEliminar.setAttribute("type","button");
            btnEliminar.addEventListener('click',() => {eliminarParada(parada)});
            btnEliminar.innerHTML = "Eliminar";
            parada.appendChild(btnEliminar);
            paradasRuta.push(parada);
            mostrarParadasRuta();
        };

        // funcion para eliminar las paradas 
        // al final vuelve a llamar a la funcion de mostrarParadasRuta();
        let eliminarParada = parada => {
            let idxParada = paradasRuta.indexOf(parada);
            paradasRuta.splice(idxParada,1);
            mostrarParadasRuta();
        }


        mostrarParadasRuta();
        getParadas();

        btnAgregarParada.addEventListener("click",agregarParada);
    });
})();