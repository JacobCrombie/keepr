<template>
  <div class="vault-component col-4">
    <div class="card">
      <img class="card-img-top" :src="vaultProp.img || 'http://placehold.it/200x200'" />
      <div class="card-body">
        <i class="fa fa-times text-danger"></i>
        <h4 class="card-title">{{ vaultProp.name }}</h4>
      </div>
    </div>

  </div>
</template>


<script>
export default {
  name: 'vault-component',
  props:["vaultProp"],
  data(){
    return {}
  },
  computed:{},
  methods:{},
  components:{}
}
</script>


<style scoped>

</style>