import {productos, productosAgrupados} from "./routes.js";

const $btnProductos = document.querySelector("#btn-productos");
const $btnAbrigos = document.querySelector("#btn-abrigos");
const $btnPantalones = document.querySelector("#btn-pantalones");
const $btnCamisetas = document.querySelector("#btn-camisetas");
const $btnZapatos = document.querySelector("#btn-zapatos");

const $contList0 = document.querySelector("#list-0");
const $contList1 = document.querySelector("#list-1");
const $contList2 = document.querySelector("#list-2");
const $contList3 = document.querySelector("#list-3");
const $contList4 = document.querySelector("#list-4");

const options = {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
};

document.addEventListener("DOMContentLoaded", function () {
    loadTodosProductos();
});

$btnProductos.addEventListener("click", () => {
    $contList1.classList.add("hidden");
    $contList2.classList.add("hidden");
    $contList3.classList.add("hidden");
    $contList4.classList.add("hidden");

    $contList0.classList.remove("hidden");

    loadTodosProductos();

});
$btnAbrigos.addEventListener("click", () => {
    $contList0.classList.add("hidden");
    $contList2.classList.add("hidden");
    $contList3.classList.add("hidden");
    $contList4.classList.add("hidden");

    $contList1.classList.remove("hidden");
    loadProductosAgrupados(1);
});
$btnCamisetas.addEventListener("click", () => {
    $contList1.classList.add("hidden");
    $contList2.classList.add("hidden");
    $contList0.classList.add("hidden");
    $contList4.classList.add("hidden");

    $contList3.classList.remove("hidden");
    loadProductosAgrupados(3);

});
$btnPantalones.addEventListener("click", () => {
    $contList1.classList.add("hidden");
    $contList0.classList.add("hidden");
    $contList3.classList.add("hidden");
    $contList4.classList.add("hidden");

    $contList2.classList.remove("hidden");
    loadProductosAgrupados(2);

});
$btnZapatos.addEventListener("click", () => {
    $contList1.classList.add("hidden");
    $contList2.classList.add("hidden");
    $contList3.classList.add("hidden");
    $contList0.classList.add("hidden");

    $contList4.classList.remove("hidden");
    loadProductosAgrupados(4);

});

async function loadTodosProductos()
{
    try {
        const response = await fetch(productos, options);
    
        if (!response.ok) {
          throw new Error(`Failed. State: ${response.status}`);
        }
    
        const result = await response.json();

        result.forEach(producto => {
            const { id, name, price, imagen } = producto;
            var html = `
                    <div class="card" style="width: 15rem;">
                        <img src="${imagen}" class="card-img-top mx-auto d-block" alt="..." style="width: 100px">
                        <div class="card-body">
                          <h5 class="card-title">${name}</h5>
                          <div class="d-flex gap-2">
                            <p>Precio: ${price}</p>
                            <a href="#" class="btn btn-warning" value=p${id}>Agregar</a>
                          </div>
                        </div>
                      </div>`;
        
            $contList0.insertAdjacentHTML("beforeend", html);

        });
        
      } catch (error) {
        console.error(error);
      }
};

async function loadProductosAgrupados(tipo)
{
    try {
        const response = await fetch(productosAgrupados, options);
    
        if (!response.ok) {
          throw new Error(`Failed. State: ${response.status}`);
        }
    
        const result = await response.json();

        result.forEach(grupo => {

            const { category, products } = grupo;
            if(category == tipo){

                products.forEach(p=>
                {
                    const { id, name, price, imagen } = p;
                var html = `
                        <div class="card" style="width: 15rem;">
                            <img src="${imagen}" class="card-img-top mx-auto d-block" alt="..." style="width: 100px">
                            <div class="card-body">
                                <h5 class="card-title">${name}</h5>
                                <div class="d-flex gap-2">
                                <p>Precio: ${price}</p>
                                <a href="#" class="btn btn-warning" value=p${id}>Agregar</a>
                                </div>
                            </div>
                            </div>`;
                
                            switch (tipo) {
                                case 1:
                                    $contList1.insertAdjacentHTML("beforeend", html);
                                    break;
                                case 2:
                                    $contList2.insertAdjacentHTML("beforeend", html);
                                  break;
                                case 3:
                                    $contList3.insertAdjacentHTML("beforeend", html);
                                  break;
                                case 4:
                                    $contList4.insertAdjacentHTML("beforeend", html);
                                  break;
                                  default:
                                    console.log("What are you doing?");
                                }
            
                });
                
            }
        });
        
      } catch (error) {
        console.error(error);
      }
}




