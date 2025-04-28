var table;


function DataTableGenerate() {

    table = $("#tblDenetimKurulu").DataTable({
        "dom": "Bfrtip",
        "responsive": true,
        "lengthChange": true,
        "pageLength": 10,
        "autoWidth": false,
        "buttons": ["csv", "excel", "pdf", "print", "colvis"],
        language: {
            url: '/json/datatablestr.json',
        },
        ajax: { url: '/AdminPanel/Dernek/DenetimKuruluListele', type: 'post' },
        columns: [
            { data: 'id', visible: false },
            { data: 'id' },
            { data: 'adSoyad' },
            { data: 'unvan' },
            { data: 'eposta' },
            { data: 'goreveBaslangicTarihi' },
            { data: 'meslek' },
            { data: 'İkamet' },
            { data: 'resim' },
            { data: 'aktif' },
            { data: 'id' },
            { data: 'id' },


        ],
        columnDefs: [
            {
                targets: 1,
                render: function (data, type, row, meta) {

                    return meta.row + 1;

                }
            },
            {
                targets: 5,
                render: function (data, type, row, meta) {
                    var date = new Date(data);
                    var day = ("0" + date.getDate()).slice(-2);
                    var month = ("0" + (date.getMonth() + 1)).slice(-2); // Aylar 0'dan başlar
                    var year = date.getFullYear();

                    // Dönüştürülmüş tarihi dd-mm-yyyy formatında döndür
                    return day + '.' + month + '.' + year;


                }
            },
            {
                targets: 8,
                render: function (data, type, row, meta) {



                    if (data == null) {
                        return "<img  src='/adminassets/img/default-150x150.png' width='60px' />";

                    }
                    return "<img src='" + data + "' width='60px' />";

                }
            },
            {
                targets: 9,
                render: function (data, type, row, meta) {

                    var dkid = row["id"];

                    if (data)

                        return '<input dkid=' + dkid + '  type= "checkbox" data-on-text="AKTİF" data-off-text="PASİF" name = "my-checkbox" checked data-bootstrap-switch data-off-color="danger" class="chkAktif" data-on-color="success" > ';


                    else

                        return '<input dkid=' + dkid + '  type= "checkbox" data-on-text="AKTİF" data-off-text="PASİF" name = "my-checkbox"  data-bootstrap-switch data-off-color="danger" class="chkAktif" data-on-color="success" > ';

                }
            },

            {
                targets: 10,
                render: function (data, type, row, meta) {

                    return "<a class='btn btn-info btnDuzenle' dkid=" + data + ">   <i class='fas fa-pencil-alt'></i></a > ";

                }
            },

            {
                targets: 11,
                render: function (data, type, row, meta) {

                    return "<a class='btn btn-danger btnSil' dkid=" + data + "><i class='fas fa-trash'></i></a > ";
                }
            },




        ],

        initComplete: function (settings, json) {

            // Datatable initilize olduğunda
            $("input[data-bootstrap-switch]").each(function () {
                $(this).bootstrapSwitch();
            });


        },

        drawCallback: function () {

            // Arama Yapıldığında, Sayfalama Yapıldığında, Sıralama Yapıldığında Draw yapılıyor
            $("input[data-bootstrap-switch]").each(function () {
                $(this).bootstrapSwitch();
            })

           /* $('.select2').select2()*/;

        }



    }).buttons().container().appendTo('#tblDenetimKurulu_wrapper .col-md-6:eq(0)');

};

$(function () {
    DataTableGenerate();
});

$("#btnDenetimKuruluEkle").click(function () {

    var swal = Swal.fire({
        title: "LÜTFEN BEKLEYİNİZ...",
        html: "İşleminiz Yapılıyor",
        timerProgressBar: true,
        didOpen: () => {

            Swal.showLoading();

        },
    });

    var formData = new FormData();

    if ($("#FUResim")[0].files[0] != null) {

        var file = $("#FUResim")[0].files[0];
        formData.append(file.name, file);

    }

   
    var AdSoyad = $("#AdSoyad").val();
    var Unvan = $("#Unvan").val();
    var Eposta = $("#Eposta").val();
    var GoreveBaslangicTarihi = $("#GoreveBaslangicTarihi").val();
    var Meslek = $("#Meslek").val();
    var İkamet = $("#ikamet").val();
    debugger

  
    formData.append("AdSoyad", AdSoyad)
    formData.append("Unvan", Unvan)
    formData.append("Eposta", Eposta)
    formData.append("GoreveBaslangicTarihi", GoreveBaslangicTarihi)
    formData.append("Meslek", Meslek)
    formData.append("İkamet", İkamet)

    $.ajax({
        url: "/AdminPanel/Dernek/DenetimKuruluEkle",
        type: "post",
        dataType: "json",
        processData: false,
        contentType: false,
        data: formData,
        success: function (r) {
            if (r.result) {

                $("#tblDenetimKurulu").DataTable().ajax.reload();

                Swal.fire({
                    title: "İşlem Başarılı",
                    text: "Denetim Kuruluna Başarıyla Eklendi.",
                    icon: "success"
                });
                $("#modalDenetimKuruluEkle").modal("hide");
            }

            //$("#txtAciklama").val("");
            //$("#frmKategoriEkle").trigger("reset");

        },
        error: function () {

        }
    }
    );



});





$(function () {
    // Summernote
    $('.select2').select2()
    $("input[data-bootstrap-switch]").each(function () {
        $(this).bootstrapSwitch();
    })
    $(document).on('switchChange.bootstrapSwitch', '.chkAktif', function (event, state) {

        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {

                Swal.showLoading();

            },
        });

        var id = $(this).attr('dkid');
        var aktifpasif = state;
        $.ajax({
            url: "/AdminPanel/Dernek/DenetimKuruluAktifPasif",
            type: "post",
            dataType: "json",
            data: { id: id, aktif: aktifpasif },
            success: function (r) {


                swal.close();
                if (r.result) {
                    Swal.fire({
                        title: "İŞLEM BAŞARILI",
                        text: r.mesaj,
                        icon: "success"
                    });
                }
            },
            error: function () {

            }
        }
        );



    });

    $(document).on('click', '.btnDuzenle', function () {
        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {

                Swal.showLoading();

            },
        });

        var id = $(this).attr('dkid');
        $("#GId").val(id);

        $.ajax({
            url: "/AdminPanel/Dernek/DenetimKurulunuGetir",
            type: "post",
            dataType: "json",
            data: { id: id },
            success: function (r) {

                if (r.result) {

                    $("#GAdSoyad").val(r.model.adSoyad);
                    $("#GUnvan").val(r.model.unvan);
                    $("#GEposta").val(r.model.eposta);
                    $("#GGoreveBaslangicTarihi").val(r.model.goreveBaslangicTarihi);
                    $("#GMeslek").val(r.model.meslek);
                    $("#Gİkamet").val(r.model.İkamet);
                    

                    $("#GResim").attr("src", r.model.resim)
                    $("#modalDenetimKuruluGuncelle").modal('show');
                }
                swal.close();











            },
            error: function () {

            }
        }
        );



    });
    $(document).on('click', '#btnDenetimKuruluGuncelle', function () {



        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {

                Swal.showLoading();

            },
        });

        var formData = new FormData();

        if ($("#GFUResim")[0].files[0] != null) {

            var file = $("#GFUResim")[0].files[0];
            formData.append(file.name, file);

        }


       
        var AdSoyad = $("#GAdSoyad").val();
        var Unvan = $("#GUnvan").val();
        var Eposta = $("#GEposta").val();
        var GoreveBaslangicTarihi = $("#GGoreveBaslangicTarihi").val();
        var Meslek = $("#GMeslek").val();
        var İkamet = $("#Gİkamet").val();
        var Id = $("#GId").val();

       
        formData.append("AdSoyad", AdSoyad)
        formData.append("Unvan", Unvan)
        formData.append("Eposta", Eposta)
        formData.append("GoreveBaslangicTarihi", GoreveBaslangicTarihi)
        formData.append("Meslek", Meslek)
        formData.append("İkamet", İkamet)

        formData.append("Id", Id)
        $.ajax({
            url: "/AdminPanel/Dernek/DenetimKuruluGuncelle",
            type: "post",
            dataType: "json",
            processData: false,
            contentType: false,
            data: formData,
            success: function (r) {




                // ---------------Datatable Yok Edildi---------------

                $("#tblDenetimKurulu").DataTable().destroy();
                //-------------------------------------------------

                // ---------------Datatable Yeniden Oluşturuluyor.---------------
                DataTableGenerate();


                //$("#GResim").attr("src", r.model.DenetimKurulu.resim);
                var dklist = "";








                swal.close();
                if (r.result) {
                    Swal.fire({
                        title: "İŞLEM BAŞARILI",
                        text: r.mesaj,
                        icon: "success"
                    });
                }
                $("#modalDenetimKuruluGuncelle").modal("hide");




            },
            error: function () {

            }
        }
        );



    });

    $(document).on('click', '.btnSil', function () {


        var id = $(this).attr('dkid');

        Swal.fire({
            title: "UYARI",
            text: "Denetim Kurulundan Silinecek Emin Misiniz?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "SİL!",
            cancelButtonText: "VAZGEÇ!"
        }).then((result) => {
            if (result.isConfirmed) {


                $.ajax({
                    url: "/AdminPanel/Dernek/DenetimKuruluSil",
                    dataType: "json",
                    method: "post",
                    data: { id: id },
                    success: function (r) {

                        if (r.result) {
                            Swal.fire({
                                title: "İşlem Başarılı",
                                text: "Denetim Kurulu Üyesi Başarıyla Silindi.",
                                icon: "success"
                            });

                            $("#tblDenetimKurulu").DataTable().ajax.reload();

                        }

                    },
                    error: function () {

                    }
                });

            }

        });


    });
});
