<template>
  <div class="keep-component col-3 my-2">
    <div class="card" data-toggle="modal" :data-target="'#'+modalId" @click="setActiveKeep">
      <img class="card-img-top" :src="keepProp.img" />
      <div class="card-body">
        <i class="fa fa-times text-danger"></i>
        <h4 class="card-title">{{ keepProp.name }}</h4>
        <p class="card-text">{{ keepProp.description }}</p>
        <i class="fa fa-plus text-info" @click="addKeep"></i>
      </div>
    </div>
    <quick-modal :id="modalId" color="bg-danger">
      <template v-slot:body>
        <keep-details />
      </template>
    </quick-modal>
  </div>
</template>


<script>
import QuickModal from "./QuickModal"
import KeepDetails from "./KeepDetails"
export default {
  name: "keep-component",
  props: ["keepProp"],
  data() {
    return {};
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    modalId(){
      return "modal" + this.keepProp.id
    }
  },
  methods: {
    setActiveKeep() {
      this.$store.dispatch("activeKeep", this.keepProp);
    },
    addKeep() {
      let addKeepData = {
        keepId: this.keepProp.id,
        vaultId: 1,
      };
      this.$store.dispatch("addKeepToVault", addKeepData);
    },
  },
  components: {QuickModal, KeepDetails},
};
</script>


<style scoped>
</style>