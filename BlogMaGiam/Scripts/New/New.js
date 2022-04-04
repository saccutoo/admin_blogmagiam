
var common = new HIA.common();

var newJS = {};
(function (context) {
    context.NewJs = function () {

        function initialize(params) {
            pageClick();
            $('body').loadingModal('hide');
        }

        function pageClick() {
            $('.pageClick').click(function () {
                var page = $(this)[0].getAttribute("value");
                viewList(page);
            });
        }

        function add() {
            $('body').loadingModal('show');
            var options = {
                type: 'GET',
                url: params.urlAdd,
                success: function (data) {
                    $("#myModal-content").html(data);
                    $("#myModal").modal("show");
                    $('body').loadingModal('hide');

                },
                error: function (xhr) {
                    $('body').loadingModal('hide');

               }
            };
            common.ajaxWrapper(options);
        }

        function edit(id) {
            $('body').loadingModal('show');
            var options = {
                type: 'GET',
                url: params.urlEdit,
                data: {
                    id: id
                },
                success: function (data) {
                    $("#myModal-content").html(data);
                    $("#myModal").modal("show");
                    $('body').loadingModal('hide');
                },
                error: function (xhr) {
                    $('body').loadingModal('hide');
                }
            };
            common.ajaxWrapper(options);
        }

        function change() {
            $(".message-danger-error").text("");
            var check = true;
            if ($("#code").val() == null || $("#code").val() == '') {
                $("#code-message-danger").text("Do not leave blank code");
                check=false;
            }

            if ($("#type").val() == null || $("#type").val() == '') {
                $("#type-message-danger").text("You have not selected type new");
                check = false;
            }
            if ($("#type_merchant").val() == null || $("#type_merchant").val() == '') {
                $("#type_merchant-message-danger").text("You have not selected type merchant");
                check = false;
            }
            if (check) {
                $('body').loadingModal('show');
                var options = {
                    type: 'POST',
                    url: params.urlChange,
                    data: $("#form-change").serializeArray(),
                    dataType: "json",
                    success: function (data) {
                        if (data.response.StatusCode == 0 && data.response.Data.id != 0) {
                            $("#myModal").modal("hide");
                            viewList(1);
                            common.toast(true, data.response.Message);

                        }
                        else {
                            common.toast(false, data.response.Message);
                            $('body').loadingModal('hide');

                        }
                    },
                    error: function (xhr) {
                    }
                };
                common.ajaxWrapper(options);
            }
            
        }

        function viewList(pageIndex) {
            $('body').loadingModal('show');
            var paramQuery = {
                value: $("#value").val(),
                pageIndex: parseInt(pageIndex),
                pageSize: 20,
                status: $("#status").val() == '' ? 0 : $("#status").val(),
            }
            var options = {
                type: 'POST',
                url: params.urlViewList,
                data: {
                    query: paramQuery
                },
                success: function (data) {
                    $("#table-common").html(data);
                    pageClick();
                    $('body').loadingModal('hide');

                },
                error: function (xhr) {
                    $('body').loadingModal('hide');

                }
            };
            common.ajaxWrapper(options);
        }

        function updateStatus(id,status) {
            bootprompt.confirm({
                title: "Notification",
                message: "Are you sure you want to change the status of this record?",
                buttons: {
                    cancel: {
                        label: "<i class='fa fa-times'></i> No",
                    },
                    confirm: {
                        label: "<i class='fa fa-check'></i> Yes",
                    },
                },
                callback: (result) => {
                    if (result) {
                        $('body').loadingModal('show');
                        var data = {
                            id: id,
                            status: status
                        }
                        var options = {
                            type: 'POST',
                            url: params.urlUpdateStatus,
                            data: {
                                model: data
                            },
                            success: function (data) {
                                data = JSON.parse(data);
                                if (data.response.StatusCode == 0 && data.response.Data.id != 0) {
                                    viewList(1);
                                    common.toast(true, data.response.Message);
                                }
                                else {
                                    common.toast(false, data.response.Message);
                                }
                            },
                            error: function (xhr) {
                            }
                        };
                        common.ajaxWrapper(options);
                    }
                },
            });
           
        }
        return {
            initialize: initialize,
            add: add,
            change: change,
            edit: edit,
            updateStatus: updateStatus,
            viewList: viewList
        }
    }
})(newJS);