<template>
  <div class="home-page container-fluid">
    <div class="row">
      <h1 class="text-center col">Welcome to Keepr</h1>
      <button
        type="button"
        class="btn btn-primary"
        data-toggle="modal"
        data-target="#exampleModalCenter"
      >
        Add New Keep
      </button>
    </div>

    <button class="btn btn-primary" @click="toggleModal">Add New Keep</button>
    <div class="row"></div>

    <div class="row">
      <!-- Button trigger modal -->

      <!-- Modal -->
      <div
        class="modal fade"
        id="exampleModalCenter"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalCenterTitle"
        aria-hidden="true"
      >
        <div class="modal-dialog modal-dialog-centered" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="exampleModalLongTitle">
                Modal title
              </h5>
              <button
                type="button"
                class="close"
                data-dismiss="modal"
                aria-label="Close"
              >
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <form class="col" @submit.prevent="createKeep">
                <div class="form-group-inline">
                  <h4 class="text-center">Add A Keep</h4>
                  <input
                    type="text"
                    class="form-control"
                    placeholder="Name..."
                    v-model="keepData.name"
                  />
                  <input
                    type="text"
                    class="form-control"
                    placeholder="Description..."
                    v-model="keepData.description"
                  />
                  <input
                    type="text"
                    class="form-control"
                    placeholder="Image Url..."
                    v-model="keepData.img"
                  />
                  <button class="btn btn-info" type="submit">Add Keep</button>
                </div>
              </form>
            </div>
            <div class="modal-footer">
              <button
                type="button"
                class="btn btn-secondary"
                data-dismiss="modal"
              >
                Close
              </button>
              <button
                type="button"
                class="btn btn-primary"
                data-dismiss="modal"
              >
                Save changes
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="row justify-content-around">
      <keep-component v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>


<script>
import keepComponent from "../components/KeepComponent";
export default {
  name: "home-page",
  mounted() {
    this.$store.dispatch("getAllKeeps");
  },
  data() {
    return {
      keepData: {},
      toggleFormModal: false,
    };
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
  },
  methods: {
    createKeep() {
      this.$store.dispatch("createKeep", this.keepData);
      this.keepData = {};
    },
    toggleModal() {},
  },
  components: { keepComponent },
};
</script>


<style scoped>
</style>

