$(document).ready(
    function () {
        $('.datepicker').datepicker({
            dayNames: ['Domingo','Segunda','Terça','Quarta','Quinta','Sexta','Sábado','Domingo'],
            dayNamesMin: ['D','S','T','Q','Q','S','S','D'],
            dayNamesShort: ['Dom','Seg','Ter','Qua','Qui','Sex','Sáb','Dom'],
            monthNames: ['Janeiro','Fevereiro','Março','Abril','Maio','Junho','Julho','Agosto','Setembro','Outubro','Novembro','Dezembro'],
            monthNamesShort: ['Jan','Fev','Mar','Abr','Mai','Jun','Jul','Ago','Set','Out','Nov','Dez'],
            changeMonth: true,
            changeYear: true,
            minDate: "-99Y",
            dateFormat: "dd/mm/yy",
        });

        $.validator.addMethod('date',
            function (value, element, params) {
                if (this.optional(element)) {
                    return true;
                }

                var result = true;
                try {
                    $.datepicker.parseDate('dd/mm/yy', value);
                } catch (e) {
                    result = false;
                }

                return result;
            }
        )
    });