<template>
  <div class="keep-component col-3 my-2">
    <div class="card" data-toggle="modal" data-target="#keep-modal" @click="setActiveKeep">
      <img class="card-img-top" :src="keepProp.img" />
      <div class="card-body">
        <i class="fa fa-times text-danger"></i>
        <h4 class="card-title">{{ keepProp.name }}</h4>
        <p class="card-text">{{ keepProp.description }}</p>
        <i class="fa fa-plus text-info" @click="addKeep"></i>
      </div>
    </div>

<!-- Modal -->
<div class="modal fade" id="keep-modal" tabindex="-1" role="dialog">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content card">
      <div class="modal-header">
        <h5 class="modal-title" >{{keepProp.name}}</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="card-body d-flex flex-row">
      <img class="card-img-left" :src="keepProp.img" alt="">
      <div class="modal-body">
        <h5>
        {{keepProp.description}}
        </h5>
      </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary" @click="addKeep">Save changes</button>
        <div class="form-group">
          <label for=""></label>
          <select class="form-control" v-model="vaultSelect">
            <option v-for="v in myVaults" :key="v.id" :value="v.id">{{v.name}}</option>
          </select>
        </div>
      </div>
    </div>
  </div>
</div>
  </div>
</template>


<script>
export default {
  name: "keep-component",
  props: ["keepProp"],
  data() {
    return {
      vaultSelect: ""
    };
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    myVaults(){
      return this.$store.state.myVaults
    }
  },
  methods: {
    setActiveKeep() {
      this.$store.dispatch("activeKeep", this.keepProp);
    },
    addKeep() {
      console.log(this.vaultSelect);
      let addKeepData = {
        keepId: this.keepProp.id,
        vaultId: this.vaultSelect,
      };
      this.$store.dispatch("addKeepToVault", addKeepData);
      this.vaultSelect = ""
    },
  },
  components: {},
};
</script>


<style scoped>

.modal-dialog{
  max-width: 50vw;
}
</style>