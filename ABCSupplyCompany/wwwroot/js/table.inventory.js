
/*
 * Editor client script for DB table inventory
 * Created by http://editor.datatables.net/generator
 */

(function($){

$(document).ready(function() {
	var editor = new $.fn.dataTable.Editor( {
		ajax: '/Home/inventory',
		table: '#inventory',
		fields: [
			{
				"label": "Lot\/Tag Number:",
				"name": "lottag_number"
			},
			{
				"label": "Lot\/Tag Description:",
				"name": "lottag_description"
			},
			{
				"label": "Weight Net:",
				"name": "weight_net"
			},
			{
				"label": "On Hand Balance:",
				"name": "on_hand_balance"
			},
			{
				"label": "Unit of Measure:",
				"name": "unit_of_measure",
				"type": "select",
				"options": [
					"Bags",
					"Glord",
					"Glord\/Bags",
					" Drum",
					" LNP Box",
					" Bale",
					"  LNP",
					" Boxes"
				]
			}
		]
	} );

	var table = $('#inventory').DataTable( {
		dom: 'Bfrtip',
		ajax: '/Home/inventory',
		columns: [
			{
				"data": "lottag_number"
			},
			{
				"data": "lottag_description"
			},
			{
				"data": "weight_net"
			},
			{
				"data": "on_hand_balance"
			},
			{
				"data": "unit_of_measure"
			}
		],
		select: true,
		lengthChange: false
		,
		//buttons: [
		//	{ extend: 'create', editor: editor },
		//	{ extend: 'edit',   editor: editor },
		//	{ extend: 'remove', editor: editor }
		//]
	} );
} );

}(jQuery));

