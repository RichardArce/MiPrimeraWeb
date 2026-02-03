(() => {
    const Carro = {
        tabla: null,

        init() {
            this.inicializarTabla();
            //registrarEventos();
            
        },
        inicializarTabla() {
            this.tabla = $('#tblCarro').DataTable({
                ajax: {
                    url: '/Carro/ObtenerCarros',
                    type: 'GET',
                    dataSrc:'data'
                },
                columns: [
                    { data: 'id' },
                    { data: 'marca'}, 
                    { data: 'modelo' },
                    {
                        data: null, //REVISAR ERROR PROXIMA CLASE
                        title: 'Acciones',
                        orderable: false,
                        render: function (data, type, row) {
                            return 
                            'TEST';
                                //<button class="btn btn-sm btn-primary" data-id="${row.id}" > Eliminar</button >
                                   
                        }
                    }
                ],
                language: {
                    url: 'https://cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json'
                }
            });
        }



    };

    $(document).ready(() => Carro.init());

})(); //Encapsula el codigo y evita conflictos con otras librerias o codigos JS

