APPTEST_IMAGE_NAME = shape-area-test

test:
	@echo Build Docker image:
	docker build . -f Dockerfiles/test.dockerfile -t $(APPTEST_IMAGE_NAME)

	@echo Run docker container:
	docker run --rm $(APPTEST_IMAGE_NAME)