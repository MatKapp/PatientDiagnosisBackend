# Generated by Django 2.2.1 on 2019-11-14 12:50

from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Examination',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('patient_age', models.PositiveIntegerField(default=0)),
                ('pulse', models.PositiveIntegerField(default=0)),
            ],
        ),
    ]
