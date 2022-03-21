
var common = new HIA.common();

var dashboardJs = {};
(function (context) {
    context.DashboardJs = function () {

        function initialize(params) {
            $('body').loadingModal('hide');
        }

        function pageClick() {
            $('.pageClick').click(function () {
                var page = $(this)[0].getAttribute("value");
                viewList(page);
            });
        }

        function changeCalendar(element) {         
            var value = $(element).val();
            viewList(value);
        }

        function viewList(type) {
            $('body').loadingModal('show');
            var options = {
                type: 'GET',
                url: params.urlViewList + "?type=" + type,
                success: function (data) {
                    debugger
                    $("#card-count-click").html(data);
                    $('body').loadingModal('hide');

                },
                error: function (xhr) {
                    $('body').loadingModal('hide');
                }
            };
            common.ajaxWrapper(options);
        }

        return {
            initialize: initialize,
            viewList: viewList,
            changeCalendar: changeCalendar,
            pageClick: pageClick
        }
    }
})(dashboardJs);