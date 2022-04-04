
var common = new HIA.common();

var couponJs = {};
(function (context) {
    context.CouponJs = function () {

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
            $('body').loadingModal('show');
            var options = {
                type: 'POST',
                url: params.urlChange,
                data: $("#form-change").serializeArray(),
                dataType: "json",
                success: function (data) {
                    if (data && data.validate) {
                        common.renderMessageError(data.validates);
                        $('body').loadingModal('hide');
                        return;
                    }
                    else if (data.response.StatusCode == 0 && data.response.Data.id != 0) {
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

        function viewList(pageIndex) {
            $('body').loadingModal('show');
            var paramQuery = {
                value: $("#value").val() == null ? '' : $("#value").val(),
                pageIndex: parseInt(pageIndex),
                pageSize: 20,
                status: $("#status").val() == '' ? 0 : $("#status").val(),
                merchant: $("#merchant-filter").val(),
                type: $("#type").val(),
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
                                    $('body').loadingModal('hide');
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
                },
            });
           
        }

        function order() {
            $('body').loadingModal('show');
            var paramQuery = {
                value: "",
                status: $("#status").val() == '' ? 0 : $("#status").val(),
                merchant: $("#merchant-filter").val(),
                type: $("#type").val(),
            }
            var options = {
                type: 'POST',
                url: params.urlOrder,
                data: {
                    query: paramQuery
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

        function changeOrder() {
            $('body').loadingModal('show');
            var data = [];
            var listItem = $(".box-item");
            for (var i = 0; i < listItem.length; i++) {
                var obj = {
                    id: listItem[i].getAttribute('value'),
                    order: i
                }
                data.push(obj);
            }
            var options = {
                type: 'POST',
                url: params.urlUpdateOrder,
                data: {
                    datas: data
                },
                success: function (data) {
                    data = JSON.parse(data);
                    if (data.response.StatusCode == 0) {
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
                    $('body').loadingModal('hide');
                }
            };
            common.ajaxWrapper(options);
        }

        function clone(id) {
            $('body').loadingModal('show');
            var options = {
                type: 'GET',
                url: params.urlClone,
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

        function openLink(url) {
            window.open(url);
        }
        return {
            initialize: initialize,
            add: add,
            change: change,
            edit: edit,
            updateStatus: updateStatus,
            viewList: viewList,
            order: order,
            changeOrder: changeOrder,
            clone: clone,
            openLink: openLink
        }
    }
})(couponJs);