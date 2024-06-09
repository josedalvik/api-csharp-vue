<template>
  <div class="crear">
	<form class="mt-3" @submit="guardar" id="formulario" >
		<div class="container">
		  <div class="row">
			<div class="col-sm-12 mb-3">
				<h1>Crear contacto</h1>
			</div>
			<div class="col-sm-3 mb-3">
				Nombre:
			</div>
			<div class="col-sm-9 mb-3">
				<input 
				  type="text" 
				  placeholder="Nombre"
				  class="form-control"
				  v-model="nombre"
				>
			</div>
			<div class="col-sm-3 mb-3">
				Celular:
			</div>
			<div class="col-sm-9 mb-3">
				<input 
				  type="number" 
				  placeholder="Celular"
				  class="form-control"
				  v-model="celular"
				>
			</div>
			<div class="col-sm-12 mb-3">
				<input class="btn btn-primary" type="submit" value="Guardar" />
			</div>
			<div class="col-sm-12 mb-3" v-if="errors.length">
				<b>Por favor, corrige los errores:</b>
				<ul>
				  <li v-for="error in errors">{{ error }}</li>
				</ul>
			</div>
		  </div>
		</div>
		<div v-if="estado==201" class="alert alert-success" role="alert">
		  Registro creado.
		</div>
		<div v-if="estado==400" class="alert alert-warning" role="alert">
		  Solicitud incorrecta.
		</div>
		<div v-if="estado==404" class="alert alert-warning" role="alert">
		  Solicitud no encontrada.
		</div>
		<div v-if="estado==204" class="alert alert-warning" role="alert">
		  Sin contenido.
		</div>
    </form>
  </div>
</template>

<style>
@media (min-width: 1024px) {
  .crear {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
<script setup>
</script>
<script>
	import {v4 as uuidv4} from 'uuid';
	export default {
	  data() { 
		return {
		  nombre: '',
		  celular: '',
		  errors: [],
		  estado: 0
		}
	  }, methods:{
		guardar: function (e) {
			e.preventDefault();
			this.estado = 0;
			this.errors = [];
			if (!this.nombre) {
				this.errors.push("El nombre es obligatorio.");
			}
			if (!this.celular) {
				this.errors.push("El celular es obligatorio.");
			}
			if(this.errors.length==0){
				let contacto = {id: uuidv4(), nombre: this.nombre, celular: this.celular};
				fetch('http://localhost:5017/api/Contacto',{
					method: "POST",
					headers: {
					  "Content-Type": "application/json",
					},
					body: JSON.stringify(contacto)
				}).then(response => this.estado = response.status);
			}
		}
      }, watch: {
		estado: function (val) {
			if( val == 201 ){
				this.nombre = '';
				this.celular = '';
			}
			setTimeout( () => this.estado = 0, 2000);
		}
	  }
	};
</script>