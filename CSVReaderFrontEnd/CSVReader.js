var CSVReader = {
	loadData: function(){
		$.ajax({url: "http://localhost:5000/api/Contacts", success: function(result){
			CSVReader.populateTable(result);
		}});
	},
	populateTable: function(contactsReslt){	
		var table = $('#contactsTable').DataTable();
		table.clear();
		for(var i = 0; i < contactsReslt.result.length; i++){
			table.row.add([
				contactsReslt.result[i].first_name 
				, contactsReslt.result[i].last_name 
				, contactsReslt.result[i].job_title
				, contactsReslt.result[i].emailaddress1 
				, contactsReslt.result[i].department
				, contactsReslt.result[i].contact_type 
				, contactsReslt.result[i].company_name 
				, contactsReslt.result[i].business_phone 
				, contactsReslt.result[i].address1_street1
				, contactsReslt.result[i].address1_street2 
				, contactsReslt.result[i].address1_city 
				, contactsReslt.result[i].address1_postalcode
				, contactsReslt.result[i].address1_country
			])
		}
		table.draw();		
	},
	clearTable: function(){
		var r = confirm("Are you sure?");
		if (r == true) {
			$.ajax({
				url: "http://localhost:5000/api/Contacts", 
				type: 'DELETE',
				success: function(result){
					CSVReader.loadData();
				}
			});
		}
	}
}

document.getElementById("uploadBtn").onchange = function () {
    document.getElementById("uploadFile").value = this.value.substring(12);
};

$(document).ready(function() {
	CSVReader.loadData();
});

$('#csvForm').submit( function( e ) {
	if($("#uploadBtn").val()){
		$.ajax( {
			url:'http://localhost:5000/api/FileReader',
			type: 'POST',
			data: new FormData( this ),
			processData: false,
			contentType: false,
			success:function(){
				CSVReader.loadData();
			},
			error:function(error){
				alert(error);
			}
		} );
		document.getElementById("csvForm").reset();
	}else{
		alert("Please select a file");
	}
	e.preventDefault();
});
