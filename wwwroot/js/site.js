//'use strict';
//import DataTableLenguajes from './modulos/lenguajes.js';
//import ajaxHelper from './modulos/HttpClient.js';

//$(document).ready(() => {

//    // defaults dataTable
//    $.extend($.fn.dataTable.defaults, {
//        language: { ...DataTableLenguajes }
//    });

//    let tables = document.querySelectorAll('table');
//    tables.forEach(tabla => $(tabla).DataTable());

//    // botones para eliminar registros de las tablas 
//    let botonesEliminarTablas = document.querySelectorAll('.botonEliminarTabla');
//    botonesEliminarTablas.forEach(boton => {
//        boton.addEventListener("click", event => {
//            event.preventDefault();
//            const id = boton.dataset.id;
//            deleteElementTable(id).done(res => console.log(res));
//        });
//    });
//});

//function deleteElementTable(id) {
//    return ajaxHelper(`concecionarios/delete/`, 'post', {
//        id: id
//    });
//}