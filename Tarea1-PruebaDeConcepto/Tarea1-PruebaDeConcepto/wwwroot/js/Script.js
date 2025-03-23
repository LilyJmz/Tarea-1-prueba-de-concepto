

//Acciones en html
document.addEventListener("DOMContentLoaded", function () {
    mostrarEmpleado();
    console.log("Script.js se ha cargado correctamente");
});

document.addEventListener('DOMContentLoaded', function () {
    try {
        const button = document.getElementById('irInsertarEmpleado');
        button.addEventListener('click', function () {
            window.location.href = 'InsertarEmpleado.html';
        });
    }
    catch {
        return (null);
    }
});

document.addEventListener('DOMContentLoaded', function () {
    try {
        const button = document.getElementById('accionInsertar');
        button.addEventListener('click', function () {
        const nombre = document.getElementById('nombre').value;
        const salarioStr = document.getElementById('salario').value;

        const nameRegex = /^[a-zA-Z\s\-]+$/;
        if (nombre === "") {
            alert("No puede dejar su nombre vacío");
        } else if (!nameRegex.test(nombre)) {
            alert("No puede ingresar caracteres especiales en su nombre");
        } else if (!/^\d+(\.\d{1,2})?$/.test(salarioStr)) {
            alert("Solo puede ingresar números y un punto decimal en su salario");
        }
        else if (salario === "") {
            alert("No puede dejar el salario vacío");
        } else {

            const salario = parseFloat(salarioStr);
            if (isNaN(salario)) {
                alert("Solo puede ingresar números y un punto decimal en su salario");
            } else {
                    insertarEmpleado(nombre, salario);
            }
        }
        });
    }
    catch {
        return (null);
        }
});

document.addEventListener('DOMContentLoaded', function () {
    try {
        const button = document.getElementById('regresarInsertarVista');
        button.addEventListener('click', function () {
            window.location.href = 'VistaUsuario.html';
        });
    }
    catch {
        return (null);
    }
});


// Llamar a stored procedures
function insertarEmpleado(nombre, salario) {
    try {
        fetch('https://localhost:5001/api/BDController/InsertarControlador', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                Nombre: nombre,
                Salario: salario
            }),
        }).then(respuesta => respuesta.json())
            .then(datos => console.log(datos))
        if (respuesta.status === 400) {
            alert("El empleado ya está registrado")
        }
        else {
            alert("Empleado insertado exitosamente");
        }
    }
    catch {
        alert("El empleado ya está registrado")
    }
}


function mostrarEmpleado() {
    try {
        fetch('https://localhost:5001/api/BDController/MostrarControlador')
            .then(respuesta => respuesta.json())  // Convierte la respuesta a JSON
            .then(datos => {
                console.log("Respuesta recibida del servidor:", datos);

                const tbody = document.querySelector("#datosTabla");

                if (datos.length == 0) {
                    const trInicio = document.createElement("tr");
                    const tdNoData = document.createElement("td");
                    tdNoData.colSpan = 3;
                    tdNoData.textContent = "La tabla está vacía.";
                    trInicio.appendChild(tdNoData);
                    tbody.appendChild(trInicio);
                } else {
                    datos.forEach((empleado) => {
                        const trInicio = document.createElement("tr");

                        let tdId = document.createElement("td");
                        tdId.textContent = empleado.id;  // Asume que el campo es 'id'
                        trInicio.appendChild(tdId);

                        let tdNombre = document.createElement("td");
                        tdNombre.textContent = empleado.nombre;  // Asume que el campo es 'nombre'
                        trInicio.appendChild(tdNombre);

                        let tdSaldo = document.createElement("td");
                        tdSaldo.textContent = empleado.salario;  // Asume que el campo es 'salario'
                        trInicio.appendChild(tdSaldo);

                        tbody.appendChild(trInicio);
                    });
                }

            })
            .catch(error => {
                console.log("No se muestra la tabla");
            });
    } catch (error) {
        console.log("No se muestra la tabla");
    }
}






