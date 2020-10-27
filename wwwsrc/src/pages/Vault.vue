<template>
  <div class="vault-page"></div>
</template>


<script>
export default {
  name: "vault-page",
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.id);
  },
  data() {
    return {};
  },
  computed: {
    vaultKeeps() {
      return this.$store.state.keeps;
    },
  },
  methods: {},
  components: {},
};
</script>


<style scoped>
</style>