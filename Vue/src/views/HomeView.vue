<template>
	<div class="container">
		<div class="row">
			<div class="col-sm-3">
				<h1>Contactos</h1>
			</div>
		</div>
		<div class="row mb-3" v-for="contacto in contactos" :key="contacto.id" >
			<div class="col-sm-3">
				Nombre:
			</div>
			<div class="col-sm-9">
				{{contacto.nombre}}
			</div>
			<div class="col-sm-3">
				Celular:
			</div>
			<div class="col-sm-9">
				{{contacto.celular}}
			</div>
			<div class="col-sm-6">
				<input class="btn btn-warning" type="button" value="Editar" @click="editar(contacto.id)" />
			</div>
			<div class="col-sm-6">
				<input class="btn btn-primary" type="button" value="Eliminar" @click="eliminar(contacto.id)" />
			</div>
		</div>
		<div v-if="estado==204" class="alert alert-success" role="alert">
		  Registro eliminado.
		</div>
		<div v-if="estado==400" class="alert alert-warning" role="alert">
		  Solicitud incorrecta.
		</div>
		<div v-if="estado==404" class="alert alert-warning" role="alert">
		  Solicitud no encontrada.
		</div>
	</div>
</template>

<script>
	export default {
	  data() {
		return {
		  contactos: [],
		  estado: 0,
		  eliminado: ""
		}
	  }, methods:{
		editar: function (id){
			window.location.href = "/editar/" + id
		},
		eliminar: function (id){
			this.estado = 0;
			this.eliminado = id;
			fetch('http://localhost:5017/api/Contacto/'+id,{
				method: "DELETE"
			}).then(response => this.estado = response.status);
		},
		getContactos(){
			fetch('http://localhost:5017/api/Contacto').then(response => response.json()).then(data => this.contactos = data);
		}
      },
	  mounted() {
		this.getContactos()
	  }, watch: {
		estado: function (val) {
			if(val==204){
				var id_eliminado = this.eliminado;
				this.contactos = this.contactos.filter(function( obj ) {
					return obj.id !== id_eliminado;
				});
			}
			setTimeout( () => this.estado = 0, 2000);
		}
	  }
	};
</script>