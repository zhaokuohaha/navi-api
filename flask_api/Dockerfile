FROM python:3.8
WORKDIR /app
COPY . .
RUN pip install --no-clean -r  requirements.txt
EXPOSE 5002

CMD [ "python", "./run.py","runserver"]