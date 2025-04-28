var table;


function DataTableGenerate() {

    table = $("#tblYonetimKurulu").DataTable({
        "dom": "Bfrtip",
        "responsive": true,
        "lengthChange": true,
        "pageLength": 10,
        "autoWidth": false,
        "buttons": ["csv", "excel", "pdf", "print", "colvis"],
        language: {
            url: '/json/datatablestr.json',
        },
        ajax: { url: '/AdminPanel/Dernek/YonetimKuruluListele', type: 'post' },
        columns: [
            { data: 'id', visible: false },
            { data: 'id' }, //entity küçültülmüş
            { data: 'adSoyadi' },
            { data: 'unvan' },
            { data: 'eposta' },
            { data: 'goreveBaslangicTarihi' },
            { data: 'meslek' },
            { data: 'İkamet' },
            { data: 'resim' },
            { data: 'aciklama' },
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
                targets: 10,
                render: function (data, type, row, meta) {

                    var ykid = row["id"];

                    if (data)

                        return '<input ykid=' + ykid + '  type= "checkbox" data-on-text="AKTİF" data-off-text="PASİF" name = "my-checkbox" checked data-bootstrap-switch data-off-color="danger" class="chkAktif" data-on-color="success" > ';


                    else

                        return '<input ykid=' + ykid + '  type= "checkbox" data-on-text="AKTİF" data-off-text="PASİF" name = "my-checkbox"  data-bootstrap-switch data-off-color="danger" class="chkAktif" data-on-color="success" > ';

                }
            },

            {
                targets: 11,
                render: function (data, type, row, meta) {

                    return "<a class='btn btn-info btnDuzenle' ykid=" + data + ">   <i class='fas fa-pencil-alt'></i></a > ";

                }
            },

            {
                targets: 12,
                render: function (data, type, row, meta) {

                    return "<a class='btn btn-danger btnSil' ykid=" + data + "><i class='fas fa-trash'></i></a > ";
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



    }).buttons().container().appendTo('#tblYonetimKurulu_wrapper .col-md-6:eq(0)');

};

$(function () {
    DataTableGenerate();
});

$("#btnYonetimKuruluEkle").click(function () {

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

    var AdSoyadi = $("#AdSoyadi").val();
    var Unvan = $("#Unvan").val();
    var Eposta = $("#Eposta").val();
    var GoreveBaslangicTarihi = $("#GoreveBaslangicTarihi").val();
    var Meslek = $("#Meslek").val();
    var İkamet = $("#ikamet").val();
    var Aciklama = $("#Aciklama").val();
    

    formData.append("AdSoyadi", AdSoyadi)  //form dataya nasıl ekliyorsak controllerda o isimle data içine alıyoruz.
    formData.append("Unvan", Unvan)
    formData.append("Eposta", Eposta)
    formData.append("GoreveBaslangicTarihi", GoreveBaslangicTarihi)
    formData.append("Meslek", Meslek)
    formData.append("İkamet", İkamet)
    formData.append("Aciklama", Aciklama)
    
    $.ajax({
        url: "/AdminPanel/Dernek/YonetimKuruluEkle",
        type: "post",
        dataType: "json",
        processData: false,
        contentType: false,
        data: formData,
        success: function (r) {
            if (r.result) {

                $("#tblYonetimKurulu").DataTable().ajax.reload();

                Swal.fire({
                    title: "İşlem Başarılı",
                    text: "Yönetim Kuruluna Başarıyla Eklendi.",
                    icon: "success"
                });
                $("#modalYonetimKuruluEkle").modal("hide");
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
    $('#Aciklama').summernote();
    $('#GAciklama').summernote();
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

        var id = $(this).attr('ykid');
        var aktifpasif = state;
        $.ajax({
            url: "/AdminPanel/Dernek/YonetimKuruluAktifPasif",
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

        var id = $(this).attr('ykid');
        $("#GId").val(id);

        $.ajax({
            url: "/AdminPanel/Dernek/YonetimKurulunuGetir",
            type: "post",
            dataType: "json",
            data: { id: id },
            success: function (r) {

                if (r.result) {

                    $("#GAdSoyad").val(r.model.adSoyadi);
                    $("#GUnvan").val(r.model.unvan);
                    $("#GEposta").val(r.model.eposta);
                    $("#GGoreveBaslangicTarihi").val(r.model.goreveBaslangicTarihi);
                    $("#GMeslek").val(r.model.meslek);
                    $("#Gİkamet").val(r.model.İkamet);
                    $("#GAciklama").summernote('code', r.model.aciklama);

                    $("#GResim").attr("src", r.model.resim)
                    $("#modalYonetimKuruluGuncelle").modal('show');
                }
                swal.close();











            },
            error: function () {

            }
        }
        );



    });
    $(document).on('click', '#btnYonetimKuruluGuncelle', function () {



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



        var AdSoyadi = $("#GAdSoyad").val();
        var Unvan = $("#GUnvan").val();
        var Eposta = $("#GEposta").val();
        var GoreveBaslangicTarihi = $("#GGoreveBaslangicTarihi").val();
        var Meslek = $("#GMeslek").val();
        var İkamet = $("#Gİkamet").val();
        var Aciklama = $("#GAciklama").val();
        var Id = $("#GId").val();

        formData.append("AdSoyadi", AdSoyadi)
        formData.append("Unvan", Unvan)
        formData.append("Eposta", Eposta)
        formData.append("GoreveBaslangicTarihi", GoreveBaslangicTarihi)
        formData.append("Meslek", Meslek)
        formData.append("İkamet", İkamet)
        formData.append("Aciklama", Aciklama)

        formData.append("Id", Id)
        $.ajax({
            url: "/AdminPanel/Dernek/YonetimKuruluGuncelle",
            type: "post",
            dataType: "json",
            processData: false,
            contentType: false,
            data: formData,
            success: function (r) {




                // ---------------Datatable Yok Edildi---------------

                $("#tblYonetimKurulu").DataTable().destroy();
                //-------------------------------------------------

                // ---------------Datatable Yeniden Oluşturuluyor.---------------
                DataTableGenerate();


                //$("#GResim").attr("src", r.model.yonetimKurulu.resim);
                var yklist = "";








                swal.close();
                if (r.result) {
                    Swal.fire({
                        title: "İŞLEM BAŞARILI",
                        text: r.mesaj,
                        icon: "success"
                    });
                }
                $("#modalYonetimKuruluGuncelle").modal("hide");




            },
            error: function () {

            }
        }
        );



    });

    $(document).on('click', '.btnSil', function () {


        var id = $(this).attr('ykid');

        Swal.fire({
            title: "UYARI",
            text: "Yönetim Kurulundan Silinecek Emin Misiniz?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "SİL!",
            cancelButtonText: "VAZGEÇ!"
        }).then((result) => {
            if (result.isConfirmed) {


                $.ajax({
                    url: "/AdminPanel/Dernek/YonetimKuruluSil",
                    dataType: "json",
                    method: "post",
                    data: { id: id },
                    success: function (r) {

                        if (r.result) {
                            Swal.fire({
                                title: "İşlem Başarılı",
                                text: "Yönetim Kurulu Üyesi Başarıyla Silindi.",
                                icon: "success"
                            });

                            $("#tblYonetimKurulu").DataTable().ajax.reload();

                        }

                    },
                    error: function () {

                    }
                });

            }

        });


    });
});
