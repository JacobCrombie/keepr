<template>
  <div class="keep-component col-3">
    <div class="card">
      <img class="card-img-top" :src="keepProp.img" />
      <div class="card-body">
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
  methods: {},
  components: {},
};
</script>


<style scoped>
</style>