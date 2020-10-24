<template>
  <div class="keep-component col-3 my-2">
    <div class="card">
      <img class="card-img-top" :src="keepProp.img" />
      <div class="card-body">
        <i class="fa fa-times text-danger" @click="deleteKeep"></i>
        <h4 class="card-title">{{ keepProp.name }}</h4>
        <p class="card-text">{{ keepProp.description }}</p>
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
  computed: {},
  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepProp.id);
    },
  },
  components: {},
};
</script>


<style scoped>
</style>