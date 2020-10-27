<template>
  <div class="keep-component col-3 my-2">
    <div class="card" @click="setActiveKeep">
      <img class="card-img-top" :src="keepProp.img" />
      <div class="card-body">
        <i class="fa fa-times text-danger" @click="deleteKeep"></i>
        <h4 class="card-title">{{ keepProp.name }}</h4>
        <p class="card-text">{{ keepProp.description }}</p>
        <i class="fa fa-plus text-info" @click="addKeep"></i>
      </div>
    </div>
  </div>
</template>


<script>
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
  },
  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepProp.id);
    },
    setActiveKeep() {
      // this.$store.dispatch("activeKeep", this.keepProp);
      // console.log(this.activeKeep);
      // sa.viewActiveKeep(
      //   this.keepProp.name,
      //   this.keepProp.description,
      //   this.keepProp.img
      // );
    },
    addKeep() {
      let addKeepData = {
        keepId: this.keepProp.id,
        vaultId: 1,
      };
      this.$store.dispatch("addKeepToVault", addKeepData);
    },
  },
  components: {},
};
</script>


<style scoped>
</style>